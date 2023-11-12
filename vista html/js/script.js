/*
    al utilizar DOMContentLoaded, se aegura de que el código javascript se ejecute después de que todos
    los elementos html hayan sido creados y estén disponibles para ser manipulados.
*/
document.addEventListener('DOMContentLoaded', function(){
    //url del api que proporciona los datos de los libros
    const url = 'http://localhost:5191/api/libroAutor';

    //obtener referencia del listado de libros (cuerpo de la tabla) y el campo de búsqueda
    const listadoLibros = document.getElementById('listadoLibros');
    const campoBusqueda = document.getElementById('campoBusqueda');

    //función para obtener y mostrar los libros obtenidos de la api
    function fetchLibros(){
        //realizar una solicitud fetch al api
        fetch(url)
            .then(response => response.json()) //convertir la respuesta a formato json
            .then(data => {
                //limpiar el contenido actual del listado de libros
                listadoLibros.innerHTML = '';

                //iterar sobre cada libro los datos correspondientes
                for(const libro of data){
                    //crear una nueva fila en el listado de libros
                    const row = document.createElement('tr');

                    //asignar html a la fila con los datos del libro
                    row.innerHTML = `
                        <td>${libro.title}</td>
                        <td>${libro.nameAuthor}</td>
                        <td>${libro.chapters}</td>
                        <td>${libro.pages}</td>
                        <td>$${libro.price}</td>
                    `;

                    //agregar la fila a la listado de libros
                    listadoLibros.appendChild(row);
                }
            })
            .catch(error => console.error('Error al obtener los datos: ', error));
    }

    //llamar a la función fetchLibros para cargar los libros en la página
    fetchLibros();

    //evento campo de búsqueda
    campoBusqueda.addEventListener('input', function(){
        //convertir el título de búsqueda a mínusculas para hacer la comparación sin distinción de mayúsculas
        const searchTitle = campoBusqueda.value.toLowerCase();

        //obtener todas las filas del listado de libros
        const rows = listadoLibros.getElementsByTagName('tr');

        //iterar sobre cada fila
        for(const row of rows){
            //obtener el texto del primer td (título del libro) en minúsculas
            const title = row.querySelector('td:first-child').textContent.toLowerCase();

            //establecer la visualización de la fila en función de si el título incluye el título de búsqueda
            row.style.display = title.includes(searchTitle) ? '' : 'none';
        }
    })
})