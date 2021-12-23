using System;
using 1AA_Maria.Category.Model;
using 1AA_Maria.Category.CategoryInfraestructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace 1AA_Maria.Category.categoryController
{
    [ApiController]
    [Route("[controller]")]
    public class CategoriesController : ControllerBase
    {

        private readonly ILogger<CategoriesController> _logger;
        private readonly CategoryInfraestructure repositorio;

        public CategoriesController(ILogger<CategoriesController> logger)
        {
            _logger = logger;
            repositorio = new CategoryInfraestructure();
        }

        [HttpGet (Name = "GetCategories")]
        public ActionResult<Category> Get(){
        return Ok(repositorio.getAll());
        }

        [HttpGet ("{id}", Name = "GetCategory")]
        public ActionResult<Category> Get(int id){
        Category categoria = repositorio.get(id);
        return categoria != null ? Ok(categoria) : NotFound("No se ha encontrado esa categoria");
        }
[HttpPost (Name = "CreateCategory")]
        public ActionResult<Category> Post([FromBody] Category categoriaInsertar){
        Category categoria = repositorio.get(categoriaInsertar.id);
        if(categoriaInsertar!= null){
            return Conflict("Ya existe una categoria con ese nombre amigo mio");
        }else{
           int numeroContar = repositorio.contar();
           categoriaInsertar.id = numeroContar + 1;
           repositorio.add(categoriaInsertar);
           String url = Request.Path.ToString() + "/" + categoriaInsertar.id;
           return Created(url, categoriaInsertar);
        }
        }

        [HttpPut (Name = "PutCategory")]
        public ActionResult<Category> Put([FromBody] Category categoriaRecibida){
        Category categoriaCambiar = repositorio.get(categoriaRecibida.id);
        categoriaCambiar.nombre = categoriaRecibida.nombre;
        return Ok("Categoria cambiada");
        }


        [HttpDelete ("{id}", Name = "DeleteCategory")]
        public ActionResult<Category> Delete(int id){
        Category categoriaEliminar = repositorio.get(id);
        return Ok("Categoria cambiada");
        }
    }
}