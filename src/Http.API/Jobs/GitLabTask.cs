﻿namespace Http.API.Jobs;

public class GitLabTask : BackgroundService
{
    private readonly ILogger<GitLabTask> _logger;
    private Timer? _timer;
    private readonly IServiceProvider Services;
    public GitLabTask(ILogger<GitLabTask> logger, IServiceProvider services)
    {
        _logger = logger;
        Services = services;
    }


    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _logger.LogInformation("gitlab task run");
        _timer = new Timer(DoWork, stoppingToken, TimeSpan.FromSeconds(3), TimeSpan.FromHours(2));
        return Task.CompletedTask;
    }

    private async void DoWork(object? state)
    {
        using var scope = Services.CreateScope();
        var manager = scope.ServiceProvider.GetRequiredService<IGitLabUserManager>();
        await manager.SyncUserEventsAsync();
    }
}
