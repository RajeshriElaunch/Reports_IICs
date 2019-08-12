using Remotion.Data.Linq.Collections;
using Reports_IICs.DataAccess.Plantillas;
using Reports_IICs.DataModels;

namespace Reports_IICs.ViewModels.Plantillas
{
    public class PlantillaViewModel
    {

        public MyICommand DeleteCommand { get; set; }

        public PlantillaViewModel()
        {
            //GetAll();
            //DeleteCommand = new MyICommand(OnDelete, CanDelete);
        }

        public Plantilla GetByCodigoIC(string codigoIC)
        {
            return Plantillas_DA.GetPlantilla(codigoIC);
        }

        public ObservableCollection<Plantilla> Plantillas
        {
            get;
            set;
        }

        public void GetAll()
        {
            //ObservableCollection<Plantilla> lista = new ObservableCollection<Student>();

            //students.Add(new Plantilla { FirstName = "Mark", LastName = "Allain" });
            //students.Add(new Plantilla { FirstName = "Allen", LastName = "Brown" });
            //students.Add(new Plantilla { FirstName = "Linda", LastName = "Hamerski" });

            //Students = students;
        }

        private Plantilla _selectedObj;

        public Plantilla SelectedObj
        {
            get
            {
                return _selectedObj;
            }

            set
            {
                _selectedObj = value;
                DeleteCommand.RaiseCanExecuteChanged();
            }
        }

        private void OnDelete()
        {
            Plantillas.Remove(SelectedObj);
        }

        private bool CanDelete()
        {
            return SelectedObj != null;
        }

        public int GetCount()
        {
            return Plantillas.Count;
        }
    }
}