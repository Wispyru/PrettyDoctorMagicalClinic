# 🧪 Testing Guide - Level Popup System

## Overview
This guide shows you how to test:
1. Locked buttons (visual feedback)
2. Score display with star ratings (test 6.4)
3. Previous score functionality

---

## 🎯 Test Scenarios

### Test 1: Locked Buttons (Visual Feedback)

**What to test:**
- Locked levels show lock icon
- Locked levels appear dimmed
- Locked levels can't be clicked
- Only unlocked levels show popup

**How to test:**

1. **Initial State (Default)**
   - Launch game
   - Level 1 button: Should be bright/enabled ✓
   - Level 2+ buttons: Should be dimmed/locked ✓
   - Lock icon visible on levels 2+ ✓

2. **Try Clicking Locked Level**
   - Click Level 2 button (should be locked)
   - Expected: Nothing happens (or shake animation only)
   - Pop should NOT appear ✗

3. **Try Clicking Unlocked Level**
   - Click Level 1 button (should be unlocked)
   - Expected: Popup slides up smoothly ✓
   - Shows level info and stars ✓

---

### Test 2: Score Display & Star Testing (6.4)

**What to test:**
- Stars display correctly based on score
- Different scores show different star counts
- No score shows 0 stars

**Setup (Using Debug System):**

1. **Add DebugLevelSystem to Scene**
   - Create empty GameObject in your Canvas
   - Name it: "DebugManager"
   - Add component: DebugLevelSystem (the script we created)
   - Set _showDebugPanel to ON
   - Save scene

2. **Now you'll have a debug menu**
   - Press 'D' during gameplay to toggle debug panel
   - Use buttons to set scores and unlock levels

---

### Test 3: Testing 6.4 - Star Thresholds

**Minimum Score = 500**

| Scenario | Steps | Expected Result |
|----------|-------|-----------------|
| **0 Stars** | Set Level 1 score to 0 (or clear) | Shows ☆☆☆ (all gray) |
| **1 Star** | Set Level 1 score to 150 (30%) | Shows ★☆☆ (1 yellow) |
| **2 Stars** | Set Level 1 score to 300 (60%) | Shows ★★☆ (2 yellow) |
| **3 Stars** | Set Level 1 score to 650 (130%) | Shows ★★★ (all yellow) |

**How to execute:**

```
Step-by-step for 3-star test:

1. Launch game
2. Press 'D' to open debug menu
3. Click "Set Level 1 Score: 650 (3★)"
4. Click Level 1 button
5. Popup appears with ★★★ ✓
6. Check: Score shows "Best Score: 650" ✓
7. Check: Min shows "Min Score: 500" ✓
```

---

## 🛠️ Using the Debug System

### Debug Menu Buttons

**Unlock/Lock Controls:**
```
[Unlock All Levels]    → All levels playable (for testing)
[Lock All Levels]      → Only Level 1 unlocked
[Unlock Level 2 Only]  → Only Levels 1-2 unlocked
```

**Score Testing:**
```
[Set Level 1 Score: 650]  → 3 stars (100%+ of min)
[Set Level 1 Score: 300]  → 2 stars (60% of min)
[Set Level 1 Score: 150]  → 1 star (30% of min)
[Clear Level 1 Score]     → 0 stars (no score)
[Set Level 2 Score: 900]  → Test Level 2
[Clear All Scores]        → Reset everything
```

**Status Display:**
```
Shows current state:
- Unlocked Level number
- Level 1 score
- Level 2 score
```

---

## 📋 Test 6.4 Detailed Checklist

### Initial Setup
- [ ] Debug scene has DebugLevelSystem component
- [ ] _showDebugPanel is toggled ON
- [ ] LevelMenu has popup configured
- [ ] Stars are visible in the popup

### Test Case 1: Zero Stars (No Score)
```
1. Press 'D' to show debug menu
2. Click "Clear Level 1 Score"
3. Console shows: "✓ Cleared Level1 score"
4. Click Level 1 button
5. Popup appears
6. Verify: ☆☆☆ (all gray stars)
7. Verify: "Best Score: 0"
✅ PASS if all stars are gray
```

### Test Case 2: One Star (30%)
```
1. Press 'D' to show debug menu
2. Click "Set Level 1 Score: 150 (1★)"
3. Console shows: "✓ Set Level1 score to 150"
4. Click Level 1 button
5. Popup appears
6. Verify: ★☆☆ (1 yellow, 2 gray)
7. Verify: "Best Score: 150"
✅ PASS if exactly 1 star is yellow
```

### Test Case 3: Two Stars (60%)
```
1. Press 'D' to show debug menu
2. Click "Set Level 1 Score: 300 (2★)"
3. Console shows: "✓ Set Level1 score to 300"
4. Click Level 1 button
5. Popup appears
6. Verify: ★★☆ (2 yellow, 1 gray)
7. Verify: "Best Score: 300"
✅ PASS if exactly 2 stars are yellow
```

### Test Case 4: Three Stars (100%)
```
1. Press 'D' to show debug menu
2. Click "Set Level 1 Score: 650 (3★)"
3. Console shows: "✓ Set Level1 score to 650"
4. Click Level 1 button
5. Popup appears
6. Verify: ★★★ (all yellow)
7. Verify: "Best Score: 650"
✅ PASS if all 3 stars are yellow
```

---

## 🔒 Testing Locked Buttons

### Test Case 1: Default Locked State
```
1. Delete all PlayerPrefs (or use "Lock All Levels")
2. Launch game
3. Level 1 button:
   ✓ Bright/visible
   ✓ Clickable
   ✓ No lock icon
4. Level 2 button:
   ✓ Dimmed (0.4 alpha)
   ✓ Not clickable
   ✓ Lock icon visible
5. Level 3+ buttons: Same as Level 2
```

### Test Case 2: Try Clicking Locked
```
1. Game in default state (Level 2 locked)
2. Click Level 2 button
3. Expected: Nothing happens
4. Expected: NO popup appears ✓
5. Optional: Shake animation plays ✓
```

### Test Case 3: Unlock and Click
```
1. Press 'D' to show debug menu
2. Click "Unlock All Levels"
3. Console shows: "✓ All levels unlocked!"
4. Click Level 2 button
5. Expected: Popup appears ✓
6. Expected: Level 2 info shows ✓
7. Expected: Stars display ✓
```

### Test Case 4: Partial Unlock
```
1. Press 'D' to show debug menu
2. Click "Unlock Level 2 Only"
3. Console shows: "✓ Unlocked up to Level 2"
4. Level 1: Bright, clickable ✓
5. Level 2: Bright, clickable ✓
6. Level 3: Dimmed, locked ✓
7. Try clicking Level 3: Nothing happens ✓
8. Try clicking Level 2: Popup appears ✓
```

---

## 🎬 Animation Testing

### Popup Animation
```
Click Level 1 button
  ↓
Popup should smoothly slide UP from bottom
  - Duration: ~0.5 seconds (adjust in LevelMenu)
  - Easing: Smooth curve (OutCubic)
  - No stuttering
  ✓ PASS if smooth animation
```

### Close Animation
```
Click "Close" button
  ↓
Popup should smoothly slide DOWN
  - Back to original position
  - Duration: ~0.5 seconds
  - No stuttering
  ✓ PASS if smooth animation
```

### Star Animation (if using StarRatingAnimated)
```
Open popup with StarRatingAnimated
  ↓
Stars should fill in sequence
  - Star 1 fills first (0.0-0.4s)
  - Star 2 fills second (0.4-0.8s)
  - Star 3 fills third (0.8-1.2s)
  - Smooth color transition
  ✓ PASS if sequential fill
```

---

## 📊 Test Matrix

| Component | Test | Expected | Status |
|-----------|------|----------|--------|
| **Locked Buttons** | Click locked | No popup | ☐ |
| | Click unlocked | Popup appears | ☐ |
| **Star Display** | 0 score | ☆☆☆ | ☐ |
| | 150 score | ★☆☆ | ☐ |
| | 300 score | ★★☆ | ☐ |
| | 650 score | ★★★ | ☐ |
| **Score Display** | Show correct score | Matches PlayerPrefs | ☐ |
| **Animations** | Popup open | Smooth slide up | ☐ |
| | Popup close | Smooth slide down | ☐ |
| **Buttons** | Proceed | Level loads | ☐ |
| | Close | Back to menu | ☐ |

---

## 🐛 Common Issues & Solutions

### Issue: Locked buttons still clickable
**Solution:**
- Check CanvasGroup interactable property
- Verify SetButtonState() is called
- Check that OnLevelButtonClicked checks canvasGroup.interactable

### Issue: Stars not showing
**Solution:**
- Verify StarRating component added to StarContainer
- Check _stars array has 3 images assigned
- Verify SetStars() is being called in PopulatePanel()

### Issue: Score shows 0 always
**Solution:**
- Use debug menu to set score
- Verify PlayerPrefs.SetInt is being called
- Check key name matches: "Score_Level1", "Score_Level2", etc.
- Call PlayerPrefs.Save() after setting

### Issue: Wrong stars displaying
**Solution:**
- Check thresholds in StarRating.SetStars():
  - 30% = 1 star
  - 60% = 2 stars
  - 100% = 3 stars
- Verify minimum score in data matches calculation
- Check color assignments (yellow vs gray)

---

## ✅ Final Test Checklist

Before considering complete:

**Locked Level Features:**
- [ ] Level 1 unlocked, others locked by default
- [ ] Locked levels show lock icon
- [ ] Locked levels are dimmed (0.4 alpha)
- [ ] Cannot click locked levels
- [ ] Clicking unlocked level opens popup

**Score & Star Testing (6.4):**
- [ ] No score shows 0 stars (☆☆☆)
- [ ] 30% score shows 1 star (★☆☆)
- [ ] 60% score shows 2 stars (★★☆)
- [ ] 100% score shows 3 stars (★★★)
- [ ] Score text displays correctly
- [ ] Minimum score displays correctly

**Popup Functionality:**
- [ ] Popup appears with animation
- [ ] Level name displays
- [ ] Description displays
- [ ] Best score displays
- [ ] Stars display and fill correctly
- [ ] Proceed button works
- [ ] Close button works
- [ ] Popup closes with animation

**Animation Quality:**
- [ ] Smooth popup slide-up
- [ ] Smooth popup slide-down
- [ ] No stuttering
- [ ] Correct duration (~0.5s)

---

## 🎮 Quick Test Script

**Copy this to console or create a quick test method:**

```csharp
// In DebugLevelSystem or similar
public void QuickTest()
{
    // Test all 4 star scenarios quickly
    Debug.Log("=== QUICK TEST SEQUENCE ===");

    // Test 1: No stars
    ClearScore("Level1");
    Debug.Log("1. Cleared score - click Level 1 (expect ☆☆☆)");

    // Wait a bit, then continue in next call
    Invoke("QuickTest2", 3f);
}

public void QuickTest2()
{
    // Test 2: 1 star
    SetScore("Level1", 150);
    Debug.Log("2. Set 150 - click Level 1 (expect ★☆☆)");
    Invoke("QuickTest3", 3f);
}

public void QuickTest3()
{
    // Test 3: 2 stars
    SetScore("Level1", 300);
    Debug.Log("3. Set 300 - click Level 1 (expect ★★☆)");
    Invoke("QuickTest4", 3f);
}

public void QuickTest4()
{
    // Test 4: 3 stars
    SetScore("Level1", 650);
    Debug.Log("4. Set 650 - click Level 1 (expect ★★★)");
}
```

---

## 📝 Test Report Template

Use this to document your testing:

```
DATE: ___________
TESTER: ___________

LOCKED BUTTONS:
- Default unlock state: ✓ ☐
- Lock icons visible: ✓ ☐
- Dimming applied: ✓ ☐
- Cannot click locked: ✓ ☐

STAR TESTING (6.4):
- 0 stars (no score): ✓ ☐
- 1 star (30%): ✓ ☐
- 2 stars (60%): ✓ ☐
- 3 stars (100%): ✓ ☐

ANIMATIONS:
- Popup open smooth: ✓ ☐
- Popup close smooth: ✓ ☐
- Star fill smooth: ✓ ☐

BUTTONS:
- Proceed works: ✓ ☐
- Close works: ✓ ☐

ISSUES FOUND:
_____________________________________________
_____________________________________________

OVERALL STATUS: ✓ PASS  ☐ FAIL
```

---

## 🎯 Summary

You can now test everything using:

1. **DebugLevelSystem.cs** - For manual testing
2. **Debug Menu** - Press 'D' to toggle
3. **Console Commands** - In code

All features can be tested in about 15-20 minutes!
