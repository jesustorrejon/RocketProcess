using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web.Virtualization;
using Microsoft.AspNetCore.Components.Web;
using RocketProcess.Shared.Utilidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using static MudBlazor.CategoryTypes;

namespace RocketProcess.Razor.Pages.Estandar
{
    public partial class Grilla<T>
    {
        //private T data;
        //public Grilla(T _data)
        //{
        //    data = _data;
        //}

        [Parameter]
        public string CssClass { get; set; } = "";

        [Parameter]
        public bool Virtualize { get; set; } = false;

        [Parameter]
        public bool Buscador { get; set; } = false;

        [Parameter]
        public RenderFragment Encabezado { get; set; }

        [Parameter]
        public RenderFragment<T> Fila { get; set; }

        [Parameter]
        public IEnumerable<T> Items { get; set; }

        public ICollection<T> Items2 { get; set; }

        [Parameter]
        public EventCallback<T> CapturarFila { get; set; }



        List<T> lista { get; set; }
        List<T> lista_temporal { get; set; }
        string busqueda = "";
        bool ascendente = true;

        protected override void OnInitialized()
        {
            lista = new List<T>();
            lista_temporal = new List<T>();
            lista = Items.ToList();
            lista_temporal.AddRange(lista);
            Items2 = lista_temporal;
        }

        private void Buscar(KeyboardEventArgs? e = null, object? xbusqueda = null)
        {
            if (xbusqueda is null || string.IsNullOrEmpty(xbusqueda.ToString()))
            {
                if (e != null)
                {
                    lista_temporal.Clear();
                    lista_temporal.AddRange(lista);
                }
            }
            else
            {
                lista_temporal = lista.Where(x => x.ToString().Contains(xbusqueda.ToString())).ToList();
            }
        }

        private void Ordenar()
        {
            if (ascendente)
            {
                lista_temporal = lista.OrderByDescending(x => x.ToString(), new SemiNumericComparer()).ToList();
            }
            else
            {
                lista_temporal = lista.OrderBy(x => x.ToString(), new SemiNumericComparer()).ToList();
            }
            ascendente = !ascendente;
        }
    }
}
