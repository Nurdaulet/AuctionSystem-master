namespace Application.Options.Queries.List
{
    using System.Collections.Generic;
    using Domain.Entities;

    public class ListOptionsResponseModel
    {
        public IEnumerable<BodyType> BodyTypes { get; set; }
        public IEnumerable<TransmissionType> TransmissionTypes { get; set; }
        public IEnumerable<Color> Colors { get; set; }
        public IEnumerable<Warranty> Warranties { get; set; }
        public IEnumerable<FuelType> FuelTypes { get; set; }
        public IEnumerable<RegionalSpecs> RegionalSpecs { get; set; }
    }
}