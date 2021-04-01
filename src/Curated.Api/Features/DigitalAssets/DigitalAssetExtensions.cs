using System;
using Curated.Api.Models;

namespace Curated.Api.Features
{
    public static class DigitalAssetExtensions
    {
        public static DigitalAssetDto ToDto(this DigitalAsset digitalAsset)
        {
                return new ()
                {
                    DigitalAssetId = digitalAsset.DigitalAssetId
                };
        }
        
    }
}
