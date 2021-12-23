namespace Application.Items.Commands.CreateItem
{
    using System;
    using System.Collections.Generic;
    using AutoMapper;
    using Common.Models;
    using Domain.Entities;
    using global::Common.AutoMapping.Interfaces;
    using MediatR;
    using Microsoft.AspNetCore.Http;

    public class CreateItemCommand : IRequest<Response<ItemResponseModel>>, IMapWith<Item>, IHaveCustomMapping
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public decimal StartingPrice { get; set; }
        public DateTime ItemCreatedYear { get; set; }
        public int Odometer { get; set; }
        public int HorsePower { get; set; }
        public int Doors { get; set; } 
        public int Cylinders { get; set; }
        public string SteeringSide { get; set; }
        public Guid BodyTypeId { get; set; }
        public Guid TransmissionTypeId { get; set; }
        public Guid ColorId { get; set; }
        public Guid WarrantyId { get; set; }
        public Guid FuelTypeId { get; set; }
        public Guid RegionalSpecsId { get; set; }
        public decimal MinIncrease { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public Guid SubCategoryId { get; set; }

        public Guid CategoryId { get; set; }

        public ICollection<IFormFile> Pictures { get; set; } = new HashSet<IFormFile>();
        public ICollection<ItemBadges> Badges { get; set; } = new List<ItemBadges>();
        public ICollection<ItemExtras> Extras { get; set; } = new List<ItemExtras>();
        public ICollection<ItemTechFeatures> TechFeatures { get; set; } = new List<ItemTechFeatures>();

        public void ConfigureMapping(Profile mapper)
        {
            mapper
                .CreateMap<CreateItemCommand, Item>()
                .ForMember(dest => dest.StartTime,
                    opt => opt.MapFrom(src => src.StartTime.ToUniversalTime()))
                .ForMember(dest => dest.EndTime,
                    opt => opt.MapFrom(src => src.EndTime.ToUniversalTime()))
                .ForMember(p => p.Pictures, opt => opt.Ignore());
        }
    }
}