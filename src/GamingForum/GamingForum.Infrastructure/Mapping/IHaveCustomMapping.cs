﻿namespace GamingForum.Infrastructure.Mapping
{
    using AutoMapper;

    public interface IHaveCustomMapping
    {
        void ConfigureMapping(Profile profile);
    }
}
