using CadastralPlanTerritoryWPF.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace CadastralPlanTerritoryWPF.ViewModels
{
    public class AppViewModel : INotifyPropertyChanged
    {
        private Parcel selectedParcel;
        private Build selectedBuild;
        private Construction selectedConstruction;
        private SpatialDataEntity selectedSpatialDataEntity;
        private Bound selectedBound;
        private Zone selectedZone;

        
        public Parcel SelectedParcel
        {
            get { return selectedParcel; }
            set
            {
                selectedParcel = value;
                OnPropertyChanged("SelectedParcel");
            }
        }
        public Build SelectedBuild
        {
            get { return selectedBuild; }
            set
            {
                selectedBuild = value;
                OnPropertyChanged("SelectedBuild");
            }
        }
        public Construction SelectedConstruction
        {
            get { return selectedConstruction; }
            set
            {
                selectedConstruction = value;
                OnPropertyChanged("SelectedConstruction");
            }
        }
        public SpatialDataEntity SelectedSpatialDataEntity
        {
            get { return selectedSpatialDataEntity; }
            set
            {
                selectedSpatialDataEntity = value;
                OnPropertyChanged("SelectedSpatialDataEntity");
            }
        }
        public Bound SelectedBound
        {
            get { return selectedBound; }
            set
            {
                selectedBound = value;
                OnPropertyChanged("SelectedBound");
            }
        }
        public Zone SelectedZone
        {
            get { return selectedZone; }
            set
            {
                selectedZone = value;
                OnPropertyChanged("SelectedZone");
            }
        }

        public ObservableCollection<Parcel> Parcels { get; set; }
        public ObservableCollection<Build> Builds { get; set; }
        public ObservableCollection<Construction> Constructions { get; set; }
        public ObservableCollection<SpatialDataEntity> SpatialDataEntities { get; set; }
        public ObservableCollection<Bound> Bounds { get; set; }
        public ObservableCollection<Zone> Zones { get; set; }

        /// <summary>
        /// Выбранные через Checkbox сущности
        /// </summary>
        public ObservableCollection<IEntity> SelectedEntities { get; set; }


        public void AddCheckedItemInList(object dataContext)
        {
            if (dataContext is IEntity) SelectedEntities.Add((IEntity)dataContext);
        }
        
        public void RemoveCheckedItemFromList(object dataContext)
        {
            if (dataContext is IEntity) SelectedEntities.Remove((IEntity)dataContext);
        }

        public AppViewModel() 
        {
            Parcels = 
                new ObservableCollection<Parcel>
                (
                    Data.Catalog.cadastral_blocks.cadastral_block.record_data.base_data.land_records
                );

            Builds =
                new ObservableCollection<Build>
                (
                    Data.Catalog.cadastral_blocks.cadastral_block.record_data.base_data.build_records
                );
            Constructions =
                new ObservableCollection<Construction>
                (
                    Data.Catalog.cadastral_blocks.cadastral_block.record_data.base_data.construction_records
                );
            SpatialDataEntities =
                new ObservableCollection<SpatialDataEntity>
                (
                    Data.Catalog.cadastral_blocks.cadastral_block.spatial_data
                );
            Bounds =
                new ObservableCollection<Bound>
                (
                    Data.Catalog.cadastral_blocks.cadastral_block.municipal_boundaries
                );
            Zones =
                new ObservableCollection<Zone>
                (
                    Data.Catalog.cadastral_blocks.cadastral_block.zones_and_territories_boundaries
                );

            SelectedEntities = new ObservableCollection<IEntity>();
        }

        private RelayCommand saveInXmlCommand;
        public RelayCommand SaveInXmlCommand
        {
            get
            {
                return saveInXmlCommand ??
                    (saveInXmlCommand = new RelayCommand(obj =>
                    {
                        SaveFileDialog saveFileDialog = new SaveFileDialog();
                        saveFileDialog.InitialDirectory = Environment.CurrentDirectory;
                        saveFileDialog.Filter = "xml files (*.xml)|*.xml|All files (*.*)|*.*";
                        saveFileDialog.RestoreDirectory = true;
                        if (saveFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            Data.Save(new XmlEntitiesWrap(SelectedEntities), saveFileDialog.FileName);
                            System.Windows.MessageBox.Show("Файл " + saveFileDialog.FileName + " сохранен.");
                        }                          
                    }));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
