using System;
using System.Threading.Tasks;
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
            dialogService.Show<TeamCreationDialog>(
                "Create team",
                new DialogParameters()
                {
                    ["UserId"] = userId,
                    ["OnTeamCreated"] = onTeamCreated
                },
                DialogOptions);
        }

        public static void ShowProjectCreationDialog(
            this IDialogService dialogService,
            string userId,
            Func<Task> onProjectCreated)
        {
            dialogService.Show<ProjectCreationDialog>(
                "Create project",
                new DialogParameters()
                {
                    ["UserId"] = userId,
                    ["OnProjectCreated"] = onProjectCreated
                },
                DialogOptions);
        }

        public static void ShowFriendsCreationDialog(
            this IDialogService dialogService,
            string userId,
            Func<Task> onCreated)
        {
            dialogService.Show<FriendsCreationDialog>(
                "Add friend",
                new DialogParameters()
                {
                    ["UserId"] = userId,
                    ["OnCreated"] = onCreated
                },
                DialogOptions);
        }

        public static void ShowMemberAddingDialog(
            this IDialogService dialogService,
            int teamId,
            Func<Task> onCreated)
        {
            dialogService.Show<MemberAddingDialog>(
                "Add member",
                new DialogParameters()
                {
                    ["TeamId"] = teamId,
                    ["OnCreated"] = onCreated
                },
                DialogOptions);
        }

        public static async Task<bool?> ShowDeleteConfirmingDialog(
            this IDialogService dialogService,
            string message = "Are you sure you want to delete this item?")
        {
            return await dialogService.ShowMessageBox(
                title: "Confirm deleting",
                message: message,
                cancelText: "Cancel",
                options: DialogOptions);
        }
    }
}
