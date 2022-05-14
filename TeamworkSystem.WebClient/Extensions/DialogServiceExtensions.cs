using Microsoft.Extensions.Localization;
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
            int ratingId,
            IStringLocalizer<SharedLocalization> sl)
        {
            dialogService.Show<RatingDialog>(
                sl["Rating"],
                new DialogParameters { ["RatingId"] = ratingId },
                DialogOptions);
        }

        public static void ShowTeamCreationDialog(
            this IDialogService dialogService,
            string userId,
            Func<Task> onCreated,
            IStringLocalizer<SharedLocalization> sl)
        {
            dialogService.Show<TeamCreationDialog>(
                sl["CreateTeam"],
                new DialogParameters
                {
                    ["UserId"] = userId,
                    ["OnCreated"] = onCreated
                },
                DialogOptions);
        }

        public static void ShowProjectCreationDialog(
            this IDialogService dialogService,
            string userId,
            Func<Task> onCreated,
            IStringLocalizer<SharedLocalization> sl)
        {
            dialogService.Show<ProjectCreationDialog>(
                sl["CreateProject"],
                new DialogParameters
                {
                    ["UserId"] = userId,
                    ["OnCreated"] = onCreated
                },
                DialogOptions);
        }

        public static void ShowTicketCreationDialog(
            this IDialogService dialogService,
            int projectId,
            Func<Task> onCreated,
            IStringLocalizer<SharedLocalization> sl)
        {
            dialogService.Show<TicketCreationDialog>(
                sl["CreateTicket"],
                new DialogParameters
                {
                    ["ProjectId"] = projectId,
                    ["OnCreated"] = onCreated
                },
                DialogOptions);
        }

        public static void ShowFriendsCreationDialog(
            this IDialogService dialogService,
            string userId,
            Func<Task> onCreated,
            IStringLocalizer<SharedLocalization> sl)
        {
            dialogService.Show<FriendsCreationDialog>(
                sl["AddFriend"],
                new DialogParameters
                {
                    ["UserId"] = userId,
                    ["OnCreated"] = onCreated
                },
                DialogOptions);
        }

        public static void ShowMemberAddingDialog(
            this IDialogService dialogService,
            int teamId,
            Func<Task> onCreated,
            IStringLocalizer<SharedLocalization> sl)
        {
            dialogService.Show<MemberAddingDialog>(
                sl["AddMember"],
                new DialogParameters
                {
                    ["TeamId"] = teamId,
                    ["OnCreated"] = onCreated
                },
                DialogOptions);
        }

        public static async Task<bool?> ShowDeleteConfirmingDialog(
            this IDialogService dialogService,
            IStringLocalizer<SharedLocalization> sl,
            string message = "Are you sure you want to delete this item?")
        {
            return await dialogService.ShowMessageBox(
                title: sl["ConfirmDeleting"],
                message: message,
                cancelText: sl["Cancel"],
                options: DialogOptions);
        }
    }
}
