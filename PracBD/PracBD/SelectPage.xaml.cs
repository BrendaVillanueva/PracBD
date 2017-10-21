using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SQLite;

namespace PracBD
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SelectPage : ContentPage
    {
        SQLiteConnection database;

        public SelectPage(object selectedItem)
        {
            var dato = selectedItem as TESHDatos;
            BindingContext = dato;
            InitializeComponent();
            string db;
            db = DependencyService.Get<ISQLite>().GetLocalFilePath("PractMD.db");
            database = new SQLiteConnection(db);
        }

        private void Button_Actualizar_Clicked(object sender, EventArgs e)
        {
            var datos = new TESHDatos
            {

                Matricula = Convert.ToInt32(Entry_Matricula.Text),
                Nombre = Entry_Nombre.Text,
                Apellido = Entry_Apellido.Text,
                Direccion = Entry_Direccion.Text,
                Telefono = Convert.ToInt32(Entry_Telefono),
                Carrera =Entry_Carrera.Text,
                Semestre = Entry_Semestre.Text,
                Correo =Entry_Correo.Text,
                GitHub =Entry_GitHub.Text

            };

            database.Update(datos);
            Navigation.PushAsync(new DataPage());

        }

        private void Button_Eliminar_Clicked(object sender, EventArgs e)
        {
            var datos = new TESHDatos
            {
                Matricula = Convert.ToInt32(Entry_Matricula.Text),
                Nombre= Entry_Nombre.Text,
                Apellido =Entry_Apellido.Text,
                Direccion= Entry_Direccion.Text,
                Telefono= Convert.ToInt32(Entry_Telefono.Text),
                Carrera= Entry_Carrera.Text,
                Semestre= Entry_Semestre.Text,
                Correo= Entry_Correo.Text,
                GitHub= Entry_GitHub.Text

            };

            database.Delete(datos);
            Navigation.PushAsync(new DataPage());
        }
    }
}