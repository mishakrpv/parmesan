namespace Parmesan.LastSeenService.API.Model;

public class LastSeen(string userId)
{
    public string UserId { get; private set; } = userId;
    public DateTimeOffset Timestamp { get; private set; } = DateTimeOffset.UtcNow;

    public void UpdateTimestamp()
    {
        Timestamp = DateTimeOffset.UtcNow;
    }
}