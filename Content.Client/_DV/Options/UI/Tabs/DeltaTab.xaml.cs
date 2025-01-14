﻿using Content.Shared._DV.CCVars;
using Robust.Client.AutoGenerated;
using Robust.Client.UserInterface;
using Robust.Client.UserInterface.Controls;
using Robust.Client.UserInterface.XAML;
using Robust.Shared.Configuration;

namespace Content.Client._DV.Options.UI.Tabs;

[GenerateTypedNameReferences]
public sealed partial class DeltaTab : Control
{
    [Dependency] private readonly IConfigurationManager _cfg = default!;

    public DeltaTab()
    {
        RobustXamlLoader.Load(this);
        IoCManager.InjectDependencies(this);

        Control.AddOptionCheckBox(DCCVars.NoVisionFilters, DisableFiltersCheckBox);
    }
}