using Abp.Application.Services;
using Taskever.Application.Services.Dto.Friendships;

namespace Taskever.Application.Services
{
    public interface IFriendshipService : IApplicationService
    {
        GetFriendshipsOutput GetFriendships(GetFriendshipsInput input);

        GetFriendshipsByMostActiveOutput GetFriendshipsByMostActive(GetFriendshipsByMostActiveInput input);

        ChangeFriendshipPropertiesOutput ChangeFriendshipProperties(ChangeFriendshipPropertiesInput input);

        SendFriendshipRequestOutput SendFriendshipRequest(SendFriendshipRequestInput input);

        RemoveFriendshipOutput RemoveFriendship(RemoveFriendshipInput input);

        AcceptFriendshipOutput AcceptFriendship(AcceptFriendshipInput input);

        RejectFriendshipOutput RejectFriendship(RejectFriendshipInput input);

        CancelFriendshipRequestOutput CancelFriendshipRequest(CancelFriendshipRequestInput input);

        UpdateLastVisitTimeOutput UpdateLastVisitTime(UpdateLastVisitTimeInput input);
    }
}