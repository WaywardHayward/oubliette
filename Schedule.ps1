Param(
    [Parameter(Mandatory=$true, HelpMessage="The Project path")]
    [string]
    $project_path
)

$task_action = New-ScheduledTaskAction -Execute "dotnet run $project_path"
$task_trigger = New-ScheduledTaskTrigger -AtLogOn

Register-ScheduledTask -TaskName "Launch Oubliette Download Organizer" -Action $task_action -Trigger $task_trigger