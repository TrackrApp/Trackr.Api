using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trackr.Api.Shared.Domain;

namespace Trackr.Api.ViewModels
{
    /// <summary>
    /// Event View Model, overridin the Event entity.
    /// </summary>
    public class EventViewModel : EventEntity
    {        
        /// <summary>
        /// Override the byte[] image with a base64 string.
        /// </summary>
        public new string HeaderImage { get; set; }        
    }
}