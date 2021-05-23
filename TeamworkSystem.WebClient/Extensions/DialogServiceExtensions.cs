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

        public static void ShowRatingDialog(
            this IDialogService dialogService,
            int ratingId)
        {
            dialogService.Show<RatingDialog>(
                "Rating",
                new DialogParameters() { ["RatingId"] = ratingId },
                DialogOptions);
        }

        public static void ShowTeamCreationDialog(
            this IDialogService dialogService,
            string userId,
            Func<Task> onCreated)
        {
            dialogService.Show<TeamCreationDialog>(
                "Create team",
                new DialogParameters()
                {
                    ["UserId"] = userId,
                    ["OnCreated"] = onCreated
                },
                DialogOptions);
        }

        public static void ShowProjectCreationDialog(
            this IDialogService dialogService,
            string userId,
            Func<Task> onCreated)
        {
            dialogService.Show<ProjectCreationDialog>(
                "Create project",
                new DialogParameters()
                {
                    ["UserId"] = userId,
                    ["OnCreated"] = onCreated
                },
                DialogOptions);
        }

        public static void ShowTicketCreationDialog(
            this IDialogService dialogService,
            int projectId,
            Func<Task> onCreated)
        {
            dialogService.Show<TicketCreationDialog>(
                "Create ticket",
                new DialogParameters()
                {
                    ["ProjectId"] = projectId,
                    ["OnCreated"] = onCreated
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
