using System;
using System.Threading.Tasks;
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
            IStringLocalizer<SharedLocalization> SL)
        {
            dialogService.Show<RatingDialog>(
                SL["Rating"],
                new DialogParameters() { ["RatingId"] = ratingId },
                DialogOptions);
        }

        public static void ShowTeamCreationDialog(
            this IDialogService dialogService,
            string userId,
            Func<Task> onCreated,
            IStringLocalizer<SharedLocalization> SL)
        {
            dialogService.Show<TeamCreationDialog>(
                SL["CreateTeam"],
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
            Func<Task> onCreated,
            IStringLocalizer<SharedLocalization> SL)
        {
            dialogService.Show<ProjectCreationDialog>(
                SL["CreateProject"],
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
            Func<Task> onCreated,
            IStringLocalizer<SharedLocalization> SL)
        {
            dialogService.Show<TicketCreationDialog>(
                SL["CreateTicket"],
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
            Func<Task> onCreated,
            IStringLocalizer<SharedLocalization> SL)
        {
            dialogService.Show<FriendsCreationDialog>(
                SL["AddFriend"],
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
            Func<Task> onCreated,
            IStringLocalizer<SharedLocalization> SL)
        {
            dialogService.Show<MemberAddingDialog>(
                SL["AddMember"],
                new DialogParameters()
                {
                    ["TeamId"] = teamId,
                    ["OnCreated"] = onCreated
                },
                DialogOptions);
        }

        public static async Task<bool?> ShowDeleteConfirmingDialog(
            this IDialogService dialogService,
            IStringLocalizer<SharedLocalization> SL,
            string message = "Are you sure you want to delete this item?")
        {
            return await dialogService.ShowMessageBox(
                title: SL["ConfirmDeleting"],
                message: message,
                cancelText: SL["Cancel"],
                options: DialogOptions);
        }
    }
}
