using Content.Client.UserInterface.Controls;
using Content.Shared.Cargo;
using Robust.Client.AutoGenerated;
using Robust.Client.UserInterface;
using Robust.Client.UserInterface.XAML;

namespace Content.Client.Cargo.UI;

[GenerateTypedNameReferences]
public sealed partial class CargoBountyMenu : FancyWindow
{
    public Action<string>? OnLabelButtonPressed;
    public Action<string>? OnSkipButtonPressed;

    public CargoBountyMenu()
    {
        RobustXamlLoader.Load(this);
    }

    public void UpdateEntries(List<CargoBountyData> bounties, List<CargoBountyHistoryData> history, TimeSpan untilNextSkip)
    {
        MasterTabContainer.SetTabTitle(0, Loc.GetString("bounty-console-tab-available-label"));
        MasterTabContainer.SetTabTitle(1, Loc.GetString("bounty-console-tab-history-label"));

        BountyEntriesContainer.Children.Clear();
        foreach (var b in bounties)
        {
            var entry = new BountyEntry(b, untilNextSkip);
            entry.OnLabelButtonPressed += () => OnLabelButtonPressed?.Invoke(b.Id);
            entry.OnSkipButtonPressed += () => OnSkipButtonPressed?.Invoke(b.Id);

            BountyEntriesContainer.AddChild(entry);
        }
        BountyEntriesContainer.AddChild(new Control
        {
            MinHeight = 10
        });

        BountyHistoryContainer.Children.Clear();
        foreach (var h in history)
        {
            var entry = new BountyHistoryEntry(h);
            BountyHistoryContainer.AddChild(entry);
        }
    }
}
