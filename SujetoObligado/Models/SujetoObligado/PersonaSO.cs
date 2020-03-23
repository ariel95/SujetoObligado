using SujetoObligado.Models.API_Externa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SujetoObligado.Models.SujetoObligado
{
    public class PersonaSO
    {
        private int id;
        private string cuit;
        private string razonSocial;
        private string fechaAlta;
        private List<DetallePersonaSO> detalle; 
        public int Id { get => id; set => id = value; }
        public string Cuit { get => cuit; set => cuit = value; }
        public string RazonSocial { get => razonSocial; set => razonSocial = value; }
        public string FechaAlta { get => fechaAlta; set => fechaAlta = value; }
        public List<DetallePersonaSO> Detalle { get => detalle; set => detalle = value; }

        public PersonaSO() {
            Detalle = new List<DetallePersonaSO>();
        }
        public PersonaSO(List<SujetoObligadoUIF> so_uif) {
            Detalle = new List<DetallePersonaSO>();
            this.Cuit = so_uif.First().Cuit;
            foreach (var item in so_uif) {
                this.Detalle.Add(new DetallePersonaSO(item));
            }
        }
    }



}