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
            string[] semestres = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12" };
            Picker_Semestre.ItemsSource = semestres;
            Picker_Semestre.SelectedItem = dato.Semestre;
            //PICKER CARRERAS
            string[] carreras = { "Ing. Sistemas Computacionales", "Ing.Industrial", "Ing.Civil","Ing. Mecatronica","Lic.Biologia","Lic. Administracion","Lic.Gastronomia"};
            Picker_Carrera.ItemsSource = carreras;
            Picker_Carrera.SelectedItem = dato.Carrera;
            
            
        }

        private void Button_Actualizar_Clicked(object sender, EventArgs e)
        {
            var datos = new TESHDatos
            {

                Matricula = Convert.ToInt32(Entry_Matricula.Text),
                Nombre = Entry_Nombre.Text,
                Apellido = Entry_Apellido.Text,
                Direccion = Entry_Direccion.Text,
                Telefono = Convert.ToInt32(Entry_Telefono.Text),
                Carrera =Convert.ToString(Picker_Carrera.SelectedItem),
                Semestre = Convert.ToString(Picker_Semestre.SelectedItem),
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
                Carrera= Convert.ToString(Picker_Carrera.SelectedItem),
                Semestre= Convert.ToString(Picker_Semestre.SelectedItem),
                Correo= Entry_Correo.Text,
                GitHub= Entry_GitHub.Text

            };

            database.Delete(datos);
            Navigation.PushAsync(new DataPage());
        }
    }
}