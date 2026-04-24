# Level Description Popup - Setup Checklist

## Pre-Setup Review
- [ ] Read `IMPLEMENTATION_SUMMARY.md` to understand the system
- [ ] Review `VISUAL_FLOW_DIAGRAM.md` to see how everything connects
- [ ] Open `LevelDescriptionPanel_Setup.cs` in your editor for reference

---

## Phase 1: Create Star Display (5 minutes)

### 1.1 Create StarContainer
- [ ] In Hierarchy, right-click under DescriptionPanel
- [ ] Create: Empty GameObject
- [ ] Name it: "StarContainer"
- [ ] Position it near where you want stars displayed

### 1.2 Add StarRating Component
- [ ] Select StarContainer
- [ ] Add Component: Search for "StarRating"
- [ ] (Or use "StarRatingAnimated" for fancy animations)

### 1.3 Create 3 Star Images
- [ ] Under StarContainer, create 3 UI > Image children
- [ ] Name them: Star1, Star2, Star3 (in order!)
- [ ] Set each image:
  - [ ] Make them the same size (e.g., 60x60)
  - [ ] Arrange them horizontally with spacing
  - [ ] Set color to white (optional - will be colored by script)

### 1.4 Configure StarRating Component
- [ ] Click on StarContainer to view StarRating component
- [ ] Drag Star1 to _stars[0]
- [ ] Drag Star2 to _stars[1]
- [ ] Drag Star3 to _stars[2]
- [ ] Set _filledStarColor:
  - [ ] R: 1, G: 1, B: 0, A: 1 (Yellow)
- [ ] Set _emptyStarColor:
  - [ ] R: 0.5, G: 0.5, B: 0.5, A: 1 (Gray)

---

## Phase 2: Create Text and Button UI (5 minutes)

### 2.1 Level Name Text
- [ ] Under DescriptionPanel, create: UI > TextMeshPro - Text
- [ ] Name it: "LevelNameText"
- [ ] Position at top of panel
- [ ] Set font size and style
- [ ] Sample text: "Level 1: First Steps"

### 2.2 Description Text
- [ ] Create: UI > TextMeshPro - Text
- [ ] Name it: "DescriptionText"
- [ ] Position below level name
- [ ] Make it larger area for multi-line text
- [ ] Sample text: "Treat 3 patients in the clinic"

### 2.3 Score Information Texts
- [ ] Create: UI > TextMeshPro - Text
- [ ] Name it: "MinimumScoreText"
- [ ] Sample: "Min Score: 500"
- [ ] Create another: "PlayerScoreText"
- [ ] Sample: "Best Score: 650"

### 2.4 Proceed Button
- [ ] Create: UI > Button (TextMeshPro)
- [ ] Name it: "ProceedButton"
- [ ] Set button text to: "Proceed" or "Start Level"
- [ ] Position at bottom right

### 2.5 Close Button
- [ ] Create: UI > Button (TextMeshPro)
- [ ] Name it: "CloseButton"
- [ ] Set button text to: "Close" or "Back"
- [ ] Position at bottom left

---

## Phase 3: Configure LevelMenu Inspector (5 minutes)

### 3.1 Basic References
- [ ] Select LevelMenu GameObject
- [ ] View LevelMenu component in Inspector

### 3.2 Panel References
- [ ] _descriptionPanel: Drag "DescriptionPanel" here
- [ ] _descriptionPanelRect: Drag "DescriptionPanel" RectTransform here
- [ ] _panelHiddenPosY: Set to -1200 (off-screen)
- [ ] _panelShownPosY: Set to 0 (on-screen)
- [ ] _panelTweenDuration: Set to 0.5 (half second)

### 3.3 UI Element References
- [ ] _levelNameText: Drag "LevelNameText" here
- [ ] _descriptionText: Drag "DescriptionText" here
- [ ] _minimumScoreText: Drag "MinimumScoreText" here
- [ ] _playerScoreText: Drag "PlayerScoreText" here
- [ ] _starRating: Drag "StarContainer" here
- [ ] _proceedButton: Drag "ProceedButton" here
- [ ] _closeButton: Drag "CloseButton" here

### 3.4 Level Buttons Setup
- [ ] _LevelButtons array size: Set to number of levels (e.g., 3)
- [ ] Element 0: Drag your first level button here
- [ ] Element 1: Drag your second level button here
- [ ] (etc. for each level)

---

## Phase 4: Add Level Data (5 minutes)

### 4.1 Create Level Data Array
- [ ] In LevelMenu Inspector, find _TemporaryLevelData
- [ ] Click dropdown to expand
- [ ] Set Size: Number of levels (e.g., 3)

### 4.2 Level 1 Data
- [ ] Expand Element 0
- [ ] LevelName: "Level 1: First Steps"
- [ ] Description: "Cure 3 patients in the clinic.\nMinimum accuracy required: 80%"
- [ ] MinimumScore: 500
- [ ] MaximumScore: 1000

### 4.3 Level 2 Data
- [ ] Expand Element 1
- [ ] LevelName: "Level 2: Getting Serious"
- [ ] Description: "Cure 5 patients across two rooms.\nMinimum accuracy required: 90%"
- [ ] MinimumScore: 800
- [ ] MaximumScore: 1500

### 4.4 Add More Levels (if needed)
- [ ] Repeat for each additional level
- [ ] Ensure data matches your game requirements

---

## Phase 5: Connect Button Events (5 minutes)

### 5.1 Setup Level Buttons
For each level button (Level1Button, Level2Button, etc.):

- [ ] Select the button in Hierarchy
- [ ] View Button component in Inspector
- [ ] Find "On Click ()" event
- [ ] Click the + button to add listener
- [ ] Drag LevelMenu GameObject into the object field
- [ ] Click the function dropdown
- [ ] Select: LevelMenu > OnLevelButtonClicked(int)
- [ ] In the int field, enter the level number
  - [ ] Level 1 Button: Enter 1
  - [ ] Level 2 Button: Enter 2
  - [ ] etc.

### 5.2 Setup Proceed Button
- [ ] Select "ProceedButton" in Hierarchy
- [ ] View Button component
- [ ] Find "On Click ()" event
- [ ] Click the + button to add listener
- [ ] Drag LevelMenu GameObject into the object field
- [ ] Click the function dropdown
- [ ] Select: LevelMenu > OpenLevel()

### 5.3 Setup Close Button
- [ ] Select "CloseButton" in Hierarchy
- [ ] View Button component
- [ ] Find "On Click ()" event
- [ ] Click the + button to add listener
- [ ] Drag LevelMenu GameObject into the object field
- [ ] Click the function dropdown
- [ ] Select: LevelMenu > HidePanel()

---

## Phase 6: Test and Verify (3 minutes)

### 6.1 Play Mode Test
- [ ] Press Play to enter game
- [ ] Click on an unlocked level button
- [ ] Verify popup appears with animation
- [ ] Check that level name displays
- [ ] Check that description displays
- [ ] Check that stars display (initially gray, no score yet)

### 6.2 Test Buttons
- [ ] Click "Proceed"
- [ ] Level should load (verify in scene)
- [ ] (You can press Escape or add debug button to return)

### 6.3 Test Close Button
- [ ] Go back to level menu
- [ ] Click a level button again
- [ ] Click "Close" button
- [ ] Popup should slide down and disappear
- [ ] You should be back at level menu

### 6.4 Test with Saved Scores
- [ ] Manually set PlayerPrefs score: `PlayerPrefs.SetInt("Score_Level1", 650);`
- [ ] Click level button again
- [ ] Best score should show: 650
- [ ] Stars should be full: ★★★ (if 650 >= 100% of min score)

---

## Phase 7: Optional Enhancements (Bonus)

### 7.1 Use Animated Stars (instead of basic)
- [ ] Remove StarRating component from StarContainer
- [ ] Add StarRatingAnimated component instead
- [ ] Configure same as StarRating
- [ ] Set _animationDuration to 0.4
- [ ] Toggle _animateOnSet to ON
- [ ] Test: Stars should fill in sequence when popup opens

### 7.2 Adjust Colors
- [ ] In StarRating component:
- [ ] _filledStarColor: Try Gold (1, 0.85, 0, 1)
- [ ] _emptyStarColor: Try Dark Gray (0.3, 0.3, 0.3, 1)

### 7.3 Adjust Animation Speed
- [ ] In LevelMenu:
- [ ] _panelTweenDuration: Try 0.3 for faster, 1.0 for slower
- [ ] Test different speeds until it feels right

### 7.4 Add Visual Polish
- [ ] Add background panel with semi-transparent dark overlay
- [ ] Add shadows under the popup
- [ ] Use different font sizes for hierarchy (title larger than description)
- [ ] Add icons or emojis to the description

---

## Troubleshooting Checklist

### Popup doesn't appear?
- [ ] Is _descriptionPanel set in LevelMenu?
- [ ] Is _descriptionPanel RectTransform correctly assigned?
- [ ] Are _panelHiddenPosY and _panelShownPosY different values?
- [ ] Is the level button's onClick set to OnLevelButtonClicked?

### Stars not displaying?
- [ ] Are all 3 images assigned to StarRating._stars array?
- [ ] Are the star image colors set to white (default)?
- [ ] Is StarRating component attached to StarContainer?
- [ ] Is _starRating field populated in LevelMenu?

### Score not showing?
- [ ] Have you set PlayerPrefs score? (e.g., in previous level completion)
- [ ] Is _playerScoreText assigned in LevelMenu?
- [ ] Is the text field visible on the panel?
- [ ] Check console for any errors

### Buttons not working?
- [ ] Are all buttons assigned in LevelMenu?
- [ ] Are button onClick events properly configured?
- [ ] For level buttons: Is the integer parameter set correctly (1, 2, 3)?
- [ ] For Proceed/Close: Are they calling the right functions?

### Scene not loading?
- [ ] Are your level scenes added to Build Settings?
- [ ] Are scene numbers (1, 2, 3) correct in OnLevelButtonClicked?
- [ ] Check console for SceneManager errors

---

## Final Verification Checklist

Before considering it complete:

- [ ] Popup appears when clicking level button
- [ ] Popup shows correct level name
- [ ] Popup shows correct description
- [ ] Popup shows best score (0 initially)
- [ ] Popup shows stars (gray if no score)
- [ ] Popup animates smoothly
- [ ] Proceed button loads the level
- [ ] Close button hides popup
- [ ] All UI text is readable
- [ ] Colors look professional
- [ ] No console errors

---

## Estimated Time

- Phase 1 (Stars): 5 min
- Phase 2 (UI): 5 min
- Phase 3 (LevelMenu): 5 min
- Phase 4 (Data): 5 min
- Phase 5 (Events): 5 min
- Phase 6 (Testing): 3 min
- **Total: ~30 minutes** for complete implementation

---

## Next Steps

✅ **Setup complete?** Great! Now:
1. Test with your actual game levels
2. Adjust colors and positioning to match your game style
3. Add sound effects (optional)
4. Consider animations for stars (optional)
5. Deploy and enjoy!

📚 **Need help?** Refer to:
- `LEVEL_DESCRIPTION_POPUP_GUIDE.md` - Feature documentation
- `INSPECTOR_SETUP_REFERENCE.md` - Visual inspector guide
- `VISUAL_FLOW_DIAGRAM.md` - System architecture
- `LevelDescriptionPanel_Setup.cs` - Code documentation
