using System;
using System.Collections.Generic;
using System.Text;

using PROMOCIONES.interfaces.Promociones;
using PROMOCIONES.interfaces.Navigation;
using PROMOCIONES.Models;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;


namespace PROMOCIONES.ViewModels.Promociones
{
    public class FicVmPromocionesList : INotifyPropertyChanged
    {
        public List<ce_cat_promociones> _FicSfDataGrid_ItemSource_Promociones, _FicSfDataGrid_ItemSource_PromocionesTotal;
        public ce_cat_promociones _FicSfDataGrid_SelectItem_Promociones;
        private ICommand _FicMetAddConteoICommand, _FicMetAcumuladosICommand, _FicMetDetalleICommand;
        private List<zt_cat_status> _FicSourceAutoCompleteEstatus;
        private IFicServiceNavigation IFicSrvNavigationPromociones;
        private IFicSrvPromocionesList IFicSrvPromocionesList;
        private zt_cat_estatus _IdEstatus;
        public List<ce_cat_promociones> FicSFDataGrid_ItemSource_Promociones { get { return _FicSfDataGrid_ItemSource_Promociones; } }
        public List<ce_cat_promociones> FicSfDataGrid_ItemSource_PromocionesTotal { get { return _FicSfDataGrid_ItemSource_PromocionesTotal; }  } 
        private zt_cat_estatus FicSourceAutoCompleteEstatus {get { return _FicSourceAutoCompleteEstatus; } }

        public ce_cat_promociones FicSfDataGrid_SelectItem_Promociones {
            get {
                return _FicSfDataGrid_SelectItem_Promociones;
            }
            set {
                if (value != null) {
                    _FicSfDataGrid_SelectItem_Promociones = value;
                    //RaisePropertyChanged();
                }
            }
        }
        public zt_cat_estatus IdEstatus {
            get { return _IdEstatus; }
            set {
                if (value != null) {
                    _IdEstatus = value;
                    //RaisePropertyChanged("IdEstatus");
                }
            }
        }

        public FicVmPromocionesList(IFicServiceNavigation IFicServiceNavigationPromociones, IFicSrvPromocionesList IFicSrvPromocionesList)
        {
            this.IFicSrvNavigationPromociones = IFicServiceNavigationPromociones;
            this.IFicSrvPromocionesList = IFicSrvPromocionesList;
            _FicSfDataGrid_ItemSource_Promociones = new List<ce_cat_promociones>();
            _FicSfDataGrid_ItemSource_PromocionesTotal = new List<ce_cat_promociones>();
        }//CONSTRUCTOR

        public ICommand FicMetAddConteoICommand{ get { return _FicMetAddConteoICommand = _FicMetAddConteoICommand ?? new FicViewModelExecuteCommands(FicMetAddConteo) } }
        private async void FicMetAddConteo() {
            if (_FicSfDataGrid_SelectItem_Promociones != null)
            {
                object[] temp = { _FicSfDataGrid_SelectItem_Promociones, null };
                IFicSrvNavigationPromociones.FicMetNavigateTo<FicVmPromocionesConteoList>(temp);
            }
            else await App.Current.MainPage.DisplayAlert("ALERTA", "Seleccione un item", "OK");
        }

        public ICommand FicMetAcumuladosICommand { get { return _FicMetAcumuladosICommand = _FicMetAcumuladosICommand ?? new FicViewModelExecuteCommands(FicMetAcomulados); } }
        private async void FicMetAcomulados() {
            if (_FicSfDataGrid_SelectItem_Promociones != null) 
                IFicSrvNavigationPromociones.FicMetNavigateTo<FicVmInventarioAcomuladoList>(_FicSfDataGrid_SelectItem_Promociones);
            else await App.Current.MainPage.DisplayAlert("ALERTA", "Seleccione un item", "OK");
            
        }

        public ICommand FicMetDetalleICommand { get { return _FicMetDetalleICommand = _FicMetDetalleICommand ?? new FicViewExecuteCommands(FicMetDetalle); } }
        private async void FicMetDetalle()
        {
            if (_FicSfDataGrid_SelectItem_Promociones != null)
                IFicSrvNavigationPromociones.FicMetNavigateTo<FicVmPromocionesDetail>(_FicSfDataGrid_SelectItem_Promociones);
            else await App.Current.MainPage.DisplayAlert("ALERTA", "Seleccione un item", "OK");
            
        }

        public async void FicEstatus(bool encontro) {
            try
            {
                if (FicSourceAutoCompleteEstatus != null && FicSourceAutoCompleteEstatus.Count() > 0)
                {
                    _FicSfDataGrid_ItemSource_Promociones.Clear();
                    foreach (ce_cat_promociones prom in _FicSfDataGrid_ItemSource_Promociones)
                    {
                        if (IdEstatus.DesEstatus == "Todos" && encontro == true)
                        {
                            _FicSfDataGrid_ItemSource_Promociones = FicSfDataGrid_ItemSource_PromocionesTotal.ToList();
                        }
                        if (IdEstatus.DesEstatus == "En Proceso" && encontro == true)
                        {
                            if (prom.IdEstatus != "1" && prom.IdEstatus.DesEstatus != "Todos")
                            {
                                _FicSfDataGrid_ItemSource_Promociones.Add(prom);
                            }
                        }
                        if (IdEstatus.DesEstatus != "En Proceso" && IdEstatus.DesEstatus != "Todos")
                        {
                            if (prom.IdEstatus == IdEstatus.IdEstatus && encontro == true)
                            {
                                _FicSfDataGrid_ItemSource_Promociones.Add(prom);
                            }
                        }
                    }
                    RaisePropertyChanged("FicSfDataGrid_ItemSource_Inventario");
                }
            }
            catch (Exception e) { }
        }

        public async Task FicMetLoadInfoEstatus(String Estatus) {
            bool encontro = false;
            try
            {
                if (FicSourceAutoCompleteEstatus != null && FicSourceAutoCompleteEstatus.Count() > 0) {
                    foreach (zt_cat_estatus est in FicSourceAutoCompleteEstatus) {
                        if (est.DesEstatus.ToLower() == Estatus.ToLower()) { _IdEstatus = est; encontro = true; }
                        else { if (encontro == false) { /*_IdEstatus = new zt_cat_estatus(); _IdEstatus.DesEstatus = "";*/} }
                    }
                    //if(encontro == false) { _IdEstatus = (from e in FicSourceAutoCompleteEstatus where e.IdEstatus == "20" select e).ToList()[0]; )}
                }
            }
            catch(Exception e){ }
            FicEstatus(encontro);
        }

        public async void onAppearing() {
            try
            {
                _FicSourceAutoCompleteEstatus = new List<zt_cat_estatus>();
                _FicSfDataGrid_ItemSource_Promociones = new List<ce_cat_promociones>();
                _FicSfDataGrid_ItemSource_PromocionesTotal = new List<ce_cat_promociones>();
                _FicSourceAutoCompleteEstatus = await IFicSrvPromocionesList.FicMetGetEstatusList() as List<zt_cat_estatus>;
                var todos = new zt_cat_estatus() { IdEstatus = "20", DesEstatus = "Todos", FechaReg = DateTime.Today, UsuarioReg = "System" };
                var proceso = new zt_cat_estatus() { IdEstatus = "19", DesEstatus = "En Proceso", FechaReg = DateTime.Today, UsuarioReg = "System" };
                _IdEstatus = proceso;
                _FicSourceAutoCompleteEstatus.Add(todos);
                _FicSourceAutoCompleteEstatus.Add(proceso);
                RaisePropertyChanged("FicSourceAutoCompleteEstatus");
                var source_local_prom = await IFicSrvPromocionesList.FicMetGetListPromociones();
                if (source_local_prom != null)
                {
                    _FicSfDataGrid_ItemSource_Promociones.Clear();
                    _FicSfDataGrid_ItemSource_PromocionesTotal.Clear();
                    foreach (ce_cat_promociones prom in source_local_prom)
                    {
                        _FicSfDataGrid_ItemSource_Promociones.Add(prom);
                        _FicSfDataGrid_ItemSource_PromocionesTotal.Add(prom);
                    }
                }//LLENAR EL GRID
                RaisePropertyChanged("IdEstatus");
                RaisePropertyChanged("FicSfDataGrid_ItemSource_PromocionesTotal");
                RaisePropertyChanged("FicSfDataGrid_ItemSource_Promociones");
            }
            catch (Exception e)
            {
                await App.Current.MainPage.DisplayAlert("ALERTA", e.Message.ToString(), "OK");
            }
        }//SOBRE CARGA DEL METODO OnAppearing() DE LA VIEW

        #region INotifiPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        public void RaisePropertyChanged([CallerMemberName] string propertyName = "")
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
