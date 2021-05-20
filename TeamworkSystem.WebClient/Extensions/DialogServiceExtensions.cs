using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using TeamworkSystem.WebClient.Shared.Dialogs;

namespace TeamworkSystem.WebClient.Extensions
{
    public static class DialogServiceExtensions
    {
        private static DialogOptions DialogOptions => new()
        {
            CloseButton = true,
            FullWidth = true,
            MaxWidth = MaxWidth.Small
        };

        public static void ShowTeamCreationDialog(
            this IDialogService dialogService,
            string userId,
            Func<Task> onTeamCreated)
        {
            dialogService.Show<TeamCreationDialog>("Create team",
                new DialogParameters()
                {
                    ["UserId"] = userId,
                    ["OnTeamCreated"] = onTeamCreated
                },
                DialogOptions);
        }


        public static void ShowProjectCreationDialog(this IDialogService dialogService) =>
            dialogService.Show<ProjectCreationDialog>("Create project", DialogOptions);

        public static async Task<bool?> ShowTicketDeleteConfirmingDialog(this IDialogService dialogService) =>
            await dialogService.ShowMessageBox(
                title: "Confirm deleting",
                message: "Are you sure you want to delete this ticket?",
                cancelText: "Cancel",
                options: DialogOptions);
    }
}
