using Automatonymous;
using SearchAPI.Events;
using SearchAPI.Models;

namespace SearchAPI.Orchestration
{
    public class PeopleSearchStateMachine : MassTransitStateMachine<PeopleSearchRequest>
    {

        public PeopleSearchStateMachine()
        {

            InstanceState(x => x.CurrentState);

            Event(() => SearchRequestInitialized, x => x.CorrelateById(ctx => ctx.Message.SearchRequestId));
            Event(() => ProviderSearchComplete, x => x.CorrelateById(ctx => ctx.Message.SearchRequestId));

            Initially(
                When(SearchRequestInitialized)
                    .Then(ctx => { ctx.Instance.CorrelationId = ctx.Data.SearchRequestId; })
                    .TransitionTo(InProgress));

            During(InProgress, When(ProviderSearchComplete)
                .Then(ctx => { ctx.Instance.AddProviderResponse(); }));

        }


        public Event<SearchRequestInitialized> SearchRequestInitialized { get; private set; }
        public Event<ProviderSearchComplete> ProviderSearchComplete { get; private set; }


        public State Ordered;
        public State InProgress;
        public State Complete;

    }
}