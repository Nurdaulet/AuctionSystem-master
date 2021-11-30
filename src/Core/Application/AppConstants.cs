﻿namespace Application
{
    public static class AppConstants
    {
        public const string AppMainEmailAddress = "nurdaulet1312@gmail.com";
        public const string CategoriesPath = "../../Core/Application/SeedSampleData/Resources/categories.json";
        public const string AdministratorRole = "Administrator";
        public const string CreatorRole = "Creator";
        public const string PlayerRole = "Player";
        public const string DefaultPictureUrl =
            "https://res.cloudinary.com/auctionsystem/image/upload/v1547833155/default-img.jpg";

        public const int PageSize = 24;

        public const int RefreshTokenExpirationTimeInMonths = 6;
    }
}