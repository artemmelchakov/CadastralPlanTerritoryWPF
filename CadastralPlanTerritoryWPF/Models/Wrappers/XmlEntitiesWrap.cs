using CadastralPlanTerritoryWPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CadastralPlanTerritoryWPF.Models
{
    /// <summary>
    /// Класс-обертка для удобного сохранения множества сущностей в xml-файл
    /// </summary>
    [XmlType(TypeName = "records")]
    public class XmlEntitiesWrap
    {
        [XmlArray(ElementName = "land_records")]
        public List<Parcel> Parcels { get; set; }

        [XmlArray(ElementName = "build_records")]
        public List<Build> Builds { get; set; }

        [XmlArray(ElementName = "construction_records")]
        public List<Construction> Constructions { get; set; }

        [XmlArray(ElementName = "spatial_data")]
        public List<SpatialDataEntity> SpatialDataEntities { get; set; }

        [XmlArray(ElementName = "municipal_boundaries")]
        public List<Bound> Bounds { get; set; }

        [XmlArray(ElementName = "zones_and_territories_boundaries")]
        public List<Zone> Zones { get; set; }

        public XmlEntitiesWrap() { }
        public XmlEntitiesWrap(ICollection<IEntity> entities)
        {
            foreach (var entity in entities)
            {
                if (entity is Parcel)
                {
                    if (Parcels == null) { Parcels = new List<Parcel>(); }
                    Parcels.Add(entity as Parcel);
                }
                else if (entity is Build)
                {
                    if (Builds == null) { Builds = new List<Build>(); }
                    Builds.Add(entity as Build);
                }
                else if (entity is Construction)
                {
                    if (Constructions == null) { Constructions = new List<Construction>(); }
                    Constructions.Add(entity as Construction);
                }
                else if (entity is SpatialDataEntity)
                {
                    if (SpatialDataEntities == null) { SpatialDataEntities = new List<SpatialDataEntity>(); }
                    SpatialDataEntities.Add(entity as SpatialDataEntity);
                }
                else if (entity is Bound)
                {
                    if (Bounds == null) { Bounds = new List<Bound>(); }
                    Bounds.Add(entity as Bound);
                }
                else if (entity is Zone)
                {
                    if (Zones == null) { Zones = new List<Zone>(); }
                    Zones.Add(entity as Zone);
                }                    
            }
        }
    }
}
