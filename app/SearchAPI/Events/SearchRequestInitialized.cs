using System;
using System.Security.Permissions;

namespace SearchAPI.Events
{
    public class SearchRequestInitialized
    {
        public Guid SearchRequestId { get; set; }

    }
}