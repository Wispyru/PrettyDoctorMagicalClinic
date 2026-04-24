# Level Description Popup - Implementation Guide

## Overview
You now have a complete system for displaying a popup when clicking level buttons. The popup shows:
- ✅ Previous score with star ratings (3 stars max)
- ✅ Level name and description from level data
- ✅ Minimum score requirement
- ✅ Close button and Proceed button
- ✅ Smooth animations (slide up/down)

## Files Created/Modified

### 1. **StarRating.cs** (NEW)
- Basic star rating display
- 3 stars with color fill based on score percentage
- Use this for simple, instant star display

### 2. **StarRatingAnimated.cs** (NEW - Optional)
- Enhanced version with animation
- Stars fill in sequence with smooth color transition
- More polished visual effect
- Choose this if you want fancy animations

### 3. **LevelMenu.cs** (MODIFIED)
- Updated to use StarRating component instead of text
- `OpenLevel()` now uses the stored `_selectedLevelId`
- Cleaner integration with star system

### 4. **LevelDescriptionPanel_Setup.cs** (NEW)
- Complete documentation for UI setup
- Read this file for detailed inspector configuration

---

## Quick Setup Steps

### Step 1: Set Up StarRating Component (Choose ONE)

#### Option A: Basic Stars (Simpler)
```
1. Right-click in hierarchy under DescriptionPanel
2. Create empty GameObject > name it "StarContainer"
3. Add component: StarRating
4. Create 3 UI > Image children (Star1, Star2, Star3)
5. In StarRating component:
   - Drag Star1, Star2, Star3 to _stars array
   - Set _filledStarColor to yellow: (1, 1, 0, 1)
   - Set _emptyStarColor to gray: (0.5, 0.5, 0.5, 1)
```

#### Option B: Animated Stars (Fancier)
```
Same as Option A, but use StarRatingAnimated component instead
Configure:
- _stars array (same as above)
- _filledStarColor & _emptyStarColor
- _animationDuration: 0.3-0.5 seconds
- Toggle _animateOnSet: true for animations
```

### Step 2: Update Button References in LevelMenu Inspector

In the Inspector for LevelMenu script:
- **_starRating**: Drag your StarContainer here
- **_proceedButton**: Drag your "Proceed" button here
- **_closeButton**: Drag your "Close" button here

### Step 3: Configure Button Click Events

**ProceedButton:**
- Click the + button in onClick event
- Select: LevelMenu > OpenLevel()

**CloseButton:**
- Click the + button in onClick event
- Select: LevelMenu > HidePanel()

### Step 4: Add Level Data

In LevelMenu Inspector, populate _TemporaryLevelData:
```
Example for Level 1:
- Level Name: "Level 1: The Beginning"
- Description: "Cure 5 patients to unlock the next world"
- Minimum Score: 500
- Maximum Score: 1000
```

---

## Star Scoring System

The popup automatically calculates and displays stars:

| Score Range | Stars | Visual |
|------------|-------|--------|
| 0-29% of min score | ☆☆☆ | All gray (empty) |
| 30-59% of min score | ★☆☆ | 1 filled (yellow/gold) |
| 60-99% of min score | ★★☆ | 2 filled |
| 100%+ of min score | ★★★ | 3 filled (perfect!) |

**Example:**
- Minimum score needed: 500
- Your best score: 300 (60% of 500) → Shows 2 stars

---

## Popup Flow

1. **Player clicks level button**
   - `OnLevelButtonClicked(levelNumber)` is called
   - Panel stores `_selectedLevelId = levelNumber`

2. **Popup appears with animation**
   - Panel slides up from bottom (off-screen)
   - UI populates with level data
   - Stars display based on saved score

3. **Player has three options:**
   - ✅ Click "Proceed" → Loads the level scene
   - ✅ Click "Close" → Panel slides back down
   - ✅ Click outside → (Optional: add auto-close if you want)

---

## Customization Options

### Change Star Colors
In StarRating or StarRatingAnimated Inspector:
- `_filledStarColor`: Color when star is earned (default: yellow)
- `_emptyStarColor`: Color when star is not earned (default: gray)

### Change Animation Speed
In LevelMenu Inspector:
- `_panelTweenDuration`: How fast the panel slides up/down (default: 0.5-1.0 seconds)

In StarRatingAnimated Inspector:
- `_animationDuration`: How fast each star fills (default: 0.3-0.5 seconds)

### Change Star Thresholds
To modify when stars appear (currently 30%, 60%, 100%):
1. Edit `StarRating.cs` or `StarRatingAnimated.cs`
2. Find `SetStars()` method
3. Change the percentage values:
```csharp
// Current thresholds - modify these:
if (percentage >= 100f) starsToFill = 3;  // 100% = 3 stars
else if (percentage >= 60f) starsToFill = 2;   // 60% = 2 stars
else if (percentage >= 30f) starsToFill = 1;   // 30% = 1 star
```

---

## Troubleshooting

**Stars not showing?**
- Make sure you dragged the 3 Image components into the _stars array in correct order
- Check that the images have color set (not transparent)

**Panel not sliding?**
- Verify `_panelHiddenPosY` and `_panelShownPosY` are set differently
- Example: Hidden = -1200, Shown = 0

**Previous score not displaying?**
- Confirm you saved scores with: `PlayerPrefs.SetInt("Score_Level" + levelNumber, score);`
- Scores are retrieved from: `PlayerPrefs.GetInt("Score_Level" + levelNumber, 0);`

**No level loading on Proceed?**
- Make sure your level scenes are named with numbers (1, 2, 3, etc.)
- Verify scene names match the levelId being passed
- Check that scenes are added to Build Settings (File > Build Settings)

---

## File Locations

All scripts are in: `Assets/Scripts/UI/`
- StarRating.cs - Basic star display
- StarRatingAnimated.cs - Animated star display
- LevelMenu.cs - Main UI controller
- TemporaryLevelData.cs - Level data holder
- LevelDescriptionPanel_Setup.cs - Setup documentation

---

## Next Steps (Optional Enhancements)

Want to add more features? Consider:
- Sound effects when stars fill
- Confetti effect on 3-star completion
- Particle effects on button clicks
- Different background colors for locked/unlocked levels
- Swipe gestures to open/close panel
- Level preview screenshots in the description panel
