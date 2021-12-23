using 1AA_Maria.Category.Model;
using System;
using System.Collections.Generic;
namespace 1AA_Maria.Category.CategoryInfraestructure
{
    public class CategoryInfraestructure : Category
    {
        private static List<Category> categorias = new List<Category>
        {
            new Category{id = 1, nombre = "Red Social"},
            new Category{id = 2, nombre = "Deportes"},
            new Category{id = 3, nombre = "Noticias"},
            new Category{id = 4, nombre = "Otros"}
        };
        public void add (Category categoria){
            Category categoriaComprobar  = get(categoria.id);
            if(categoriaComprobar != null){
                categorias.Add(categoriaComprobar);
            }
        }
        public void remove (Category categoria){
            Category categoriaComprobar  = get(categoria.id);
            if(categoriaComprobar != null){
                categorias.Remove(categoriaComprobar);
            }
        }
        public Category get (int idCategoria){
           return categorias.Find(x => x.id == idCategoria);
        }
        public List<Category> getAll (){
           return categorias;
        }
        public int contar() {
            int numero = 0;
            foreach (var categoriaContar in categorias)
            {
                numero++;
            }
                return numero;
        }
    }
    }