using CadastralPlanTerritoryWPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CadastralPlanTerritoryWPF.Models
{
    [XmlType(TypeName = "records")]
    public class XmlEntitiesWrap
    {
        [XmlArray(ElementName = "land_records")]
        public List<Parcel> Parcels { get; set; } = new List<Parcel>();

        [XmlArray(ElementName = "build_records")]
        public List<Build> Builds { get; set; } = new List<Build>();

        [XmlArray(ElementName = "construction_records")]
        public List<Construction> Constructions { get; set; } = new List<Construction>();

        [XmlArray(ElementName = "spatial_data")]
        public List<SpatialDataEntity> SpatialDataEntities { get; set; } = new List<SpatialDataEntity>();

        [XmlArray(ElementName = "municipal_boundaries")]
        public List<Bound> Bounds { get; set; } = new List<Bound>();

        [XmlArray(ElementName = "zones_and_territories_boundaries")]
        public List<Zone> Zones { get; set; } = new List<Zone>();

        public XmlEntitiesWrap() { }
        public XmlEntitiesWrap(ICollection<IEntity> entities)
        {
            foreach (var entity in entities)
            {
                if (entity is Parcel) Parcels.Add(entity as Parcel);
                else if (entity is Build) Builds.Add(entity as Build);
                else if (entity is Construction) Constructions.Add(entity as Construction);
                else if (entity is SpatialDataEntity) SpatialDataEntities.Add(entity as SpatialDataEntity);
                else if (entity is Bound) Bounds.Add(entity as Bound);
                else if (entity is Zone) Zones.Add(entity as Zone);
            }
        }
    }
}
