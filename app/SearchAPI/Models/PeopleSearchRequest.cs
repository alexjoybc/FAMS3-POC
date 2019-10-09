using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Automatonymous;
using Microsoft.AspNetCore.Mvc.Internal;

namespace SearchAPI.Models
{
    public class PeopleSearchRequest : SagaStateMachineInstance
    {

        private int _providerResponses = 0;

        public Guid CorrelationId { get; set; }

        public string CurrentState { get; set; }

        public int ProviderRequested { get; set; }

        public int ProviderResponses
        {
            get { return _providerResponses; }
        }

        public void AddProviderResponse()
        {
            _providerResponses++;
        }

    }
}
