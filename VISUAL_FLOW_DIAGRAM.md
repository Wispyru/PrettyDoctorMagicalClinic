# Level Description Popup - Visual Flow Diagram

## User Interaction Flow

```
┌─────────────────┐
│  Level Menu     │
│                 │
│ [Level 1] [L2]  │
│ [Level 3] [L4]  │
└────────┬────────┘
         │
    User clicks
    level button
         │
         ▼
┌─────────────────────────────────────────┐
│  OnLevelButtonClicked(levelId)          │
│                                         │
│  • Store _selectedLevelId               │
│  • Load level data from array           │
│  • Populate UI elements                 │
│  • Calculate stars from saved score     │
│  • Show popup with animation            │
└────────┬────────────────────────────────┘
         │
         ▼
    ┌──────────────────────────────────────┐
    │   LEVEL DESCRIPTION POPUP            │
    ├──────────────────────────────────────┤
    │                                      │
    │  Level 1: First Steps                │
    │  ────────────────────────────────    │
    │  Treat 3 patients                    │
    │  Min accuracy: 80%                   │
    │                                      │
    │  Best Score: 650                     │
    │  Min Score: 500                      │
    │                                      │
    │  ★★★ (3 stars = 130% of min)        │
    │                                      │
    │  ┌──────────────┐  ┌──────────────┐  │
    │  │   Proceed    │  │     Close    │  │
    │  └──────┬───────┘  └──────┬───────┘  │
    │         │                  │         │
    └─────────┼──────────────────┼─────────┘
              │                  │
         YES  │                  │ NO
              │                  │
              ▼                  ▼
    ┌─────────────────┐    ┌─────────────┐
    │  Load Level     │    │ Hide Popup  │
    │  Scene          │    │ Animation   │
    │                 │    │             │
    │ SceneManager    │    │ Back to     │
    │ .LoadScene(1)   │    │ Level Menu  │
    └─────────────────┘    └─────────────┘
```

---

## Data Flow Diagram

```
┌─────────────────────────────────────────┐
│      PlayerPrefs Storage                │
│  Score_Level1: 650                      │
│  Score_Level2: 450                      │
│  Score_Level3: 0                        │
│  UnlockedLevel: 3                       │
└──────────────┬──────────────────────────┘
               │
               ▼
┌─────────────────────────────────────────┐
│    TemporaryLevelData[3] Array          │
│                                         │
│ [0] Level 1:                            │
│     Name: "First Steps"                 │
│     Description: "Treat 3 patients"     │
│     MinScore: 500                       │
│     MaxScore: 1000                      │
│                                         │
│ [1] Level 2:                            │
│     Name: "Getting Serious"             │
│     Description: "Treat 5 patients"     │
│     MinScore: 800                       │
│     MaxScore: 1500                      │
│                                         │
│ [2] Level 3: ... (etc)                  │
└──────────────┬──────────────────────────┘
               │
               ▼
┌─────────────────────────────────────────┐
│    LevelMenu.PopulatePanel()            │
│                                         │
│  1. Get saved score from PlayerPrefs    │
│  2. Match with TemporaryLevelData       │
│  3. Calculate star rating:              │
│     • Get percentage: score/minScore    │
│     • Count stars: 30%, 60%, 100%       │
│  4. Update UI elements:                 │
│     • _levelNameText                    │
│     • _descriptionText                  │
│     • _playerScoreText                  │
│     • _starRating.SetStars()            │
└──────────────┬──────────────────────────┘
               │
               ▼
┌─────────────────────────────────────────┐
│  StarRating Component                   │
│                                         │
│  Input: score=650, minScore=500         │
│  Calculation: 650/500 = 130% = 3 stars │
│                                         │
│  Update each star image:                │
│  Star1.color = yellow (filled)          │
│  Star2.color = yellow (filled)          │
│  Star3.color = yellow (filled)          │
│                                         │
│  Display: ★★★                          │
└─────────────────────────────────────────┘
```

---

## Star Calculation Logic

```
Input: Player Score vs Minimum Required Score

Calculate Percentage:
percentage = (playerScore / minimumScore) × 100

    0% ─────────────────────────────────── 100%+
    │                                        │
    ▼                                        ▼

[No Score Yet]  [30%]  [60%]  [100%]
    ☆☆☆          ★☆☆    ★★☆    ★★★
    0 pts        150    300     500+ (if min=500)

Star Thresholds:
    0-29%   → ☆☆☆ (0 stars)
    30-59%  → ★☆☆ (1 star)
    60-99%  → ★★☆ (2 stars)
    100%+   → ★★★ (3 stars - Perfect!)

Example with Min Score = 500:
    0 points     → ☆☆☆
    150 points   → ★☆☆ (30% achieved)
    300 points   → ★★☆ (60% achieved)
    500 points   → ★★★ (100% - Perfect!)
    650 points   → ★★★ (130% - Bonus!)
```

---

## Animation Timeline

```
OPEN POPUP:
┌─────────────────────────────────────────────────┐
│ Time: 0s         0.25s         0.5s             │
├─────────────────────────────────────────────────┤
│                                                 │
│ Position:                                       │
│ Y = -1200 ────→ -600 ────→ 0 (on screen)       │
│                                                 │
│ Ease: OutCubic (smooth deceleration)           │
│                                                 │
│ If using StarRatingAnimated:                   │
│                                                 │
│ Star1: ☆ ──(0.4s)──→ ★                         │
│ Star2:           ☆ ──(0.4s)──→ ★               │
│ Star3:                    ☆ ──(0.4s)──→ ★      │
│                                                 │
└─────────────────────────────────────────────────┘

CLOSE POPUP:
┌─────────────────────────────────────────────────┐
│ Time: 0s         0.25s         0.5s             │
├─────────────────────────────────────────────────┤
│                                                 │
│ Position:                                       │
│ Y = 0 (on screen) ────→ -600 ────→ -1200       │
│                                                 │
│ Ease: InCubic (smooth acceleration)            │
│                                                 │
│ Then: GameObject.SetActive(false)              │
│                                                 │
└─────────────────────────────────────────────────┘
```

---

## Component Architecture

```
┌──────────────────────────────────────────────────────┐
│                   LevelMenu (Main)                   │
├──────────────────────────────────────────────────────┤
│  • Manages popup show/hide                           │
│  • Handles button clicks                             │
│  • Populates UI with level data                      │
│  • Triggers scene loading                            │
│                                                      │
│  Key Methods:                                        │
│  ├─ OnLevelButtonClicked(int)                       │
│  ├─ PopulatePanel(int)                              │
│  ├─ ShowPanel()                                     │
│  ├─ HidePanel()                                     │
│  ├─ OpenLevel()                                     │
│  └─ SetupLevelButtons(int)                          │
└──────────┬───────────────────────────────────────────┘
           │
           ├─────────────────────────────────────────┐
           │                                         │
           ▼                                         ▼
    ┌─────────────────┐               ┌──────────────────────┐
    │ StarRating      │               │ TemporaryLevelData   │
    ├─────────────────┤               ├──────────────────────┤
    │ • SetStars()    │               │ • LevelName          │
    │ • ResetStars()  │               │ • Description        │
    │ • 3 star images │               │ • MinimumScore       │
    │ • Colors config │               │ • MaximumScore       │
    └─────────────────┘               └──────────────────────┘

Alternative:
    ┌──────────────────────┐
    │ StarRatingAnimated   │
    ├──────────────────────┤
    │ • SetStars() [anim]  │
    │ • Coroutines         │
    │ • Animation timing   │
    └──────────────────────┘
```

---

## Inspector Connections

```
┌─────────────────────────────────────────────────────┐
│  LevelMenu Inspector Fields                         │
├─────────────────────────────────────────────────────┤
│                                                     │
│  LevelButtons[] ─────────────┐                     │
│                              │                     │
│  _TemporaryLevelData[] ─── Level Data             │
│                                                     │
│  _descriptionPanel ───────┐                        │
│  _descriptionPanelRect    │                        │
│  _panelHiddenPosY         ├─── Animation Config   │
│  _panelShownPosY          │                        │
│  _panelTweenDuration ─────┘                        │
│                                                     │
│  _levelNameText ────┐                              │
│  _descriptionText   │                              │
│  _minimumScoreText  ├─── UI Elements              │
│  _playerScoreText   │                              │
│  _starRating ───────┤ ← StarRating Component      │
│  _proceedButton ────┼─── Button References        │
│  _closeButton ──────┘                              │
│                                                     │
└─────────────────────────────────────────────────────┘
```

---

## Game State Flow

```
START
  │
  ├─ Check UnlockedLevel in PlayerPrefs
  ├─ Initialize button lock/unlock states
  ├─ Hide popup (move off-screen)
  │
  ▼
LEVEL MENU (Waiting for input)
  │
  ├─ User clicks unlocked level button
  │
  ├─ OnLevelButtonClicked() triggered
  │ ├─ Verify level is unlocked
  │ ├─ Fetch saved score from PlayerPrefs
  │ ├─ Fetch level data from array
  │ ├─ Calculate stars from score
  │ ├─ Update all UI text
  │ ├─ Update star display
  │ ├─ Animate popup in
  │
  ├─ POPUP SHOWN (User has 2 choices)
  │
  ├─ Choice A: Click "Proceed"
  │ ├─ OpenLevel() called
  │ ├─ Load scene by level ID
  │ └─ GAME STARTS → Player plays level
  │
  ├─ Choice B: Click "Close"
  │ ├─ HidePanel() called
  │ ├─ Animate popup out
  │ └─ Back to LEVEL MENU (waiting)
  │
  └─ After Level Complete
    ├─ New score calculated
    ├─ Saved to PlayerPrefs
    ├─ Next level possibly unlocked
    ├─ Return to LEVEL MENU
    └─ (Repeat)
```

This visual flow shows exactly what happens at each step of your new popup system!
