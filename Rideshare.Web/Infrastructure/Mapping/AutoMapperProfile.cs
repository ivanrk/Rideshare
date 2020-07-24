namespace Rideshare.Web.Infrastructure.Mapping
{
    using AutoMapper;
    using Rideshare.Data.Models;
    using Rideshare.Data.Models.Forum;
    using Rideshare.Services.Models.Cars;
    using Rideshare.Services.Models.Forum;
    using Rideshare.Services.Models.Messages;
    using Rideshare.Services.Models.Travels;
    using Rideshare.Services.Models.Users;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Car, CarListingModel>()
                .ForMember(c => c.Photo, opt => opt.MapFrom(c => ConvertFromBytes(c.Photo)));

            CreateMap<Car, CarFormModel>();

            CreateMap<Car, CarDetailsModel>()
                .ForMember(c => c.Photo, opt =>
                    opt.MapFrom(c => ConvertFromBytes(c.Photo)));

            CreateMap<Travel, TravelBasicModel>();

            CreateMap<Travel, TravelListingModel>()
                .ForMember(t => t.Car, opt => opt.MapFrom(t => t.Car.Make + " " + t.Car.Model))
                .ForMember(t => t.Passengers, opt => opt.MapFrom(t => t.Passengers.Count));

            string userId = null;

            CreateMap<Travel, UserTravelListingModel>()
                .ForMember(t => t.Applicants, opt => opt.MapFrom(t => t.Applicants.Count))
                .ForMember(t => t.UserIsDriver, opt => opt.MapFrom(t => t.DriverId == userId));

            CreateMap<User, UserProfileModel>()
                .ForMember(u => u.ProfilePicture, opt => opt.MapFrom(u => ConvertFromBytes(u.ProfilePicture)))
                .ForMember(u => u.TotalVotes, opt => opt.MapFrom(u => u.Reviews.Count))
                .ForMember(u => u.AverageRating, opt => opt.MapFrom(u => SetAverageRating(u.Reviews)));

            CreateMap<User, UserDetailsModel>()
                .ForMember(u => u.ProfilePicture, opt => opt.MapFrom(u => ConvertFromBytes(u.ProfilePicture)))
                .ForMember(u => u.TimesAsAPassenger, opt => opt.MapFrom(u => u.Travels.Count(t => t.PassengerId == u.Id)))
                .ForMember(u => u.TotalVotes, opt => opt.MapFrom(u => u.Reviews.Count))
                .ForMember(u => u.AverageRating, opt => opt.MapFrom(u => SetAverageRating(u.Reviews)));

            CreateMap<User, UserBasicProfileModel>()
                .ForMember(u => u.ProfilePicture, opt => opt.MapFrom(u => ConvertFromBytes(u.ProfilePicture)))
                .ForMember(u => u.AverageRating, opt => opt.MapFrom(u => SetAverageRating(u.Reviews)));

            CreateMap<Message, MessageFormModel>();

            CreateMap<Message, MessageListingModel>();

            CreateMap<Message, MessageDetailsModel>()
                .ForMember(m => m.SenderProfilePicture, opt => opt.MapFrom(m => ConvertFromBytes(m.Sender.ProfilePicture)));

            CreateMap<Category, CategoryListingModel>();

            CreateMap<Category, CategorySubforumsModel>();
        }

        private static decimal SetAverageRating(List<Review> reviews)
        {
            if (reviews.Count > 0)
            {
                return Math.Round(reviews.Sum(r => (decimal)r.Rating) / reviews.Count);
            }

            return 0;
        }

        private static string ConvertFromBytes(byte[] photo)
        {
            if (photo != null)
            {
                return String.Format("data:image/png;base64,{0}", Convert.ToBase64String(photo));
            }

            return null;
        }
    }
}
