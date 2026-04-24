# Hierarchy and Inspector Setup Reference

## Recommended Canvas Hierarchy

```
Canvas
├── LevelMenu (Script Component)
├── LevelButtons
│   ├── Level1Button
│   ├── Level2Button
│   └── Level3Button (etc.)
└── DescriptionPanel (RectTransform)
    ├── Background Image
    ├── LevelNameText (TextMeshProUGUI)
    ├── DescriptionText (TextMeshProUGUI)
    ├── ScoreInfo
    │   ├── MinimumScoreText (TextMeshProUGUI)
    │   └── PlayerScoreText (TextMeshProUGUI)
    ├── StarContainer (Transform)
    │   ├── Add StarRating or StarRatingAnimated Component Here
    │   ├── Star1 (Image)
    │   ├── Star2 (Image)
    │   └── Star3 (Image)
    ├── ProceedButton (Button)
    └── CloseButton (Button)
```

## LevelMenu Inspector Configuration

### Header: Level Buttons
- **LevelButtons[]**: Drag all your level buttons here in order
  ```
  Element 0: Level1Button
  Element 1: Level2Button
  Element 2: Level3Button
  (etc.)
  ```

### Header: Level Data
- **_TemporaryLevelData[]**: Create one entry per level
  ```
  Element 0:
    - Level Name: "Level 1: First Steps"
    - Description: "Treat 3 patients\nMinimum accuracy: 80%"
    - Minimum Score: 500
    - Maximum Score: 1000

  Element 1:
    - Level Name: "Level 2: Getting Serious"
    - Description: "Treat 5 patients\nMinimum accuracy: 90%"
    - Minimum Score: 800
    - Maximum Score: 1500

  (etc.)
  ```

### Header: Description Panel
- **_descriptionPanel**: Drag "DescriptionPanel" GameObject from hierarchy
- **_descriptionPanelRect**: Drag "DescriptionPanel" RectTransform (same object)
- **_panelHiddenPosY**: -1200 (or set to move off-screen)
- **_panelShownPosY**: 0 (or set to center on-screen)
- **_panelTweenDuration**: 0.5 (seconds - adjust for slower/faster animation)

### Header: Panel UI Elements
- **_levelNameText**: Drag "LevelNameText" from hierarchy
- **_descriptionText**: Drag "DescriptionText" from hierarchy
- **_minimumScoreText**: Drag "MinimumScoreText" from hierarchy
- **_playerScoreText**: Drag "PlayerScoreText" from hierarchy
- **_starRating**: Drag "StarContainer" from hierarchy (has StarRating/StarRatingAnimated component)
- **_proceedButton**: Drag "ProceedButton" from hierarchy
- **_closeButton**: Drag "CloseButton" from hierarchy

## StarRating Component Inspector (Basic Version)

Select "StarContainer" in hierarchy, view StarRating component:

- **_stars[0]**: Drag "Star1" Image from hierarchy
- **_stars[1]**: Drag "Star2" Image from hierarchy
- **_stars[2]**: Drag "Star3" Image from hierarchy

- **_filledStarColor**: 
  - RGB: (1, 1, 0) - Yellow/Gold
  - Alpha: 1
  - (Or use Inspector color picker: bright yellow)

- **_emptyStarColor**:
  - RGB: (0.5, 0.5, 0.5) - Gray
  - Alpha: 1
  - (Or use Inspector color picker: medium gray)

## StarRatingAnimated Component Inspector (If Using Animated Version)

Select "StarContainer" in hierarchy, view StarRatingAnimated component:

- **_stars[0-2]**: Same as above (Star1, Star2, Star3)
- **_filledStarColor**: Yellow (1, 1, 0, 1)
- **_emptyStarColor**: Gray (0.5, 0.5, 0.5, 1)
- **_animationDuration**: 0.4 (seconds between each star filling)
- **_animateOnSet**: Toggle ON (true) for animations

## Level Button Setup (For Each Level Button)

Select a level button (e.g., "Level1Button"):

### In Button Component:
- **On Click ()** event:
  1. Click the + button to add listener
  2. Drag "LevelMenu" GameObject into the field
  3. Select: LevelMenu > OnLevelButtonClicked(int)
  4. Enter the level number (1 for first level, 2 for second, etc.)

Example for Level 1 Button:
```
On Click ()
├── Object: LevelMenu
└── Method: OnLevelButtonClicked(int) [1]
```

Example for Level 2 Button:
```
On Click ()
├── Object: LevelMenu
└── Method: OnLevelButtonClicked(int) [2]
```

## ProceedButton Setup

Select "ProceedButton":

### In Button Component:
- **On Click ()** event:
  1. Click the + button to add listener
  2. Drag "LevelMenu" GameObject into the field
  3. Select: LevelMenu > OpenLevel()

```
On Click ()
├── Object: LevelMenu
└── Method: OpenLevel()
```

## CloseButton Setup

Select "CloseButton":

### In Button Component:
- **On Click ()** event:
  1. Click the + button to add listener
  2. Drag "LevelMenu" GameObject into the field
  3. Select: LevelMenu > HidePanel()

```
On Click ()
├── Object: LevelMenu
└── Method: HidePanel()
```

---

## Quick Verification Checklist

- [ ] All 3 star images are assigned to StarRating component
- [ ] All text fields (name, description, scores) are assigned to LevelMenu
- [ ] StarRating component is assigned to LevelMenu's _starRating field
- [ ] All buttons are assigned to LevelMenu (proceed, close)
- [ ] All level buttons have OnLevelButtonClicked onClick events
- [ ] Proceed button has OpenLevel onClick event
- [ ] Close button has HidePanel onClick event
- [ ] DescriptionPanel is positioned off-screen initially
- [ ] At least one level has data in _TemporaryLevelData
- [ ] Level scenes are added to Build Settings

If all checked: **Ready to test!** 🎮
