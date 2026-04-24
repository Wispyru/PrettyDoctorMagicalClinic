# ✅ Final Checklist Before Testing

## Pre-Testing Setup

### Scene Configuration
- [ ] Level Menu scene is open
- [ ] Canvas exists in scene
- [ ] Level buttons exist (Level 1, Level 2, etc.)
- [ ] DescriptionPanel exists
- [ ] StarContainer exists with 3 star images
- [ ] LevelMenu script is attached to a GameObject

### DebugManager Setup
- [ ] DebugManager GameObject created
- [ ] DebugLevelSystem component added
- [ ] _showDebugPanel is ON (checked)
- [ ] _toggleDebugKey is set to KeyCode.D
- [ ] Scene saved

### Scripts Verification
- [ ] DebugLevelSystem.cs exists (no errors)
- [ ] LevelMenu.cs is updated (no errors)
- [ ] StarRating.cs exists (no errors)
- [ ] TemporaryLevelData has level data filled

### Inspector Check
- [ ] LevelMenu has _starRating assigned (StarContainer)
- [ ] LevelMenu has all UI elements assigned
- [ ] StarRating has all 3 stars in _stars array
- [ ] _filledStarColor is yellow (1, 1, 0)
- [ ] _emptyStarColor is gray (0.5, 0.5, 0.5)

---

## Ready to Test?

### Final Verification
- [ ] Read START_TESTING_NOW.md
- [ ] Understood what D key does
- [ ] Know where to look for results (console)
- [ ] Know what stars should look like
- [ ] Ready to click buttons

### During Testing
- [ ] Play mode is active
- [ ] D key opens debug panel
- [ ] Panel shows all buttons
- [ ] Buttons are clickable
- [ ] Console shows messages

---

## Test Execution Checklist

### Test 1: Verify Panel Works
- [ ] Press D
- [ ] Debug panel appears on left ✓
- [ ] Can see all buttons
- [ ] Can see status area
- [ ] D toggles panel on/off

**Result: PASS / FAIL**

### Test 2: Locked Buttons
- [ ] Level 1 button is bright
- [ ] Level 2 button is dimmed
- [ ] Lock icon visible on Level 2
- [ ] Click Level 2 → Nothing happens
- [ ] Click Level 1 → Popup appears

**Result: PASS / FAIL**

### Test 3: Zero Stars
- [ ] Press D
- [ ] Click "Clear Level 1 (0 stars)"
- [ ] Console shows: ✓ Cleared Level1 score
- [ ] Click Level 1 button
- [ ] Popup shows: ☆☆☆ (all gray)

**Result: PASS / FAIL**

### Test 4: One Star
- [ ] Click "Set Level 1: 150 (1 star)"
- [ ] Console shows: ✓ Set Level1 score to 150
- [ ] Close popup (click Close)
- [ ] Click Level 1 button again
- [ ] Popup shows: ★☆☆ (1 yellow, 2 gray)
- [ ] Score shows: 150

**Result: PASS / FAIL**

### Test 5: Two Stars
- [ ] Click "Set Level 1: 300 (2 stars)"
- [ ] Console shows: ✓ Set Level1 score to 300
- [ ] Close popup
- [ ] Click Level 1 button
- [ ] Popup shows: ★★☆ (2 yellow, 1 gray)
- [ ] Score shows: 300

**Result: PASS / FAIL**

### Test 6: Three Stars
- [ ] Click "Set Level 1: 650 (3 stars)"
- [ ] Console shows: ✓ Set Level1 score to 650
- [ ] Close popup
- [ ] Click Level 1 button
- [ ] Popup shows: ★★★ (all yellow)
- [ ] Score shows: 650

**Result: PASS / FAIL**

---

## Results Summary

| Test | Expected | Actual | Pass? |
|------|----------|--------|-------|
| Panel Works | Appears | ☐ YES ☐ NO | ☐ ✓ |
| Locked Buttons | Can't click | ☐ YES ☐ NO | ☐ ✓ |
| Zero Stars | ☆☆☆ | ☐ YES ☐ NO | ☐ ✓ |
| One Star | ★☆☆ | ☐ YES ☐ NO | ☐ ✓ |
| Two Stars | ★★☆ | ☐ YES ☐ NO | ☐ ✓ |
| Three Stars | ★★★ | ☐ YES ☐ NO | ☐ ✓ |

---

## If Tests Fail

### Problem: D key doesn't work
```
☐ Verify DebugManager exists
☐ Verify DebugLevelSystem attached
☐ Verify _showDebugPanel is ON
☐ Check console for errors
☐ Try restarting Play mode
```

### Problem: Panel appears but buttons don't work
```
☐ Click button, check console for message
☐ If no message: Script error
☐ If message appears: Issue with popup display
☐ Check hierarchy is set up correctly
```

### Problem: Stars don't change
```
☐ Verify message appeared in console
☐ If message: Issue with StarRating display
☐ If no message: Issue with DebugLevelSystem
☐ Check StarRating has 3 stars in array
☐ Check colors are set (yellow/gray)
```

### Problem: Locked levels still clickable
```
☐ Make sure OnLevelButtonClicked checks isUnlocked
☐ Try "Lock All Levels" button
☐ Verify CanvasGroup is set up on buttons
☐ Check interactable property
```

---

## Console Messages You Should See

### When Everything Works:
```
Debug panel ON (press D to close)
✓ All levels unlocked!
✓ Only Level 1 unlocked
✓ Set Level1 score to 150
✓ Set Level1 score to 300
✓ Set Level1 score to 650
✓ Cleared Level1 score
✓ All scores cleared!
Debug panel OFF (press D to open)
```

### When Something's Wrong:
```
[Any red error messages]
ArgumentException: ...
NullReferenceException: ...
IndexOutOfRangeException: ...
```

---

## Visual Confirmation

### After Each Test, Verify:

#### Test 3 (Zero Stars):
```
Expected Screen:
┌─────────────────────────────────┐
│ Level 1                         │
│ Best Score: 0                   │
│ Min Score: 500                  │
│ ☆☆☆ (All gray)                │
│ [Proceed] [Close]               │
└─────────────────────────────────┘
```

#### Test 4 (One Star):
```
Expected Screen:
┌─────────────────────────────────┐
│ Level 1                         │
│ Best Score: 150                 │
│ Min Score: 500                  │
│ ★☆☆ (1 yellow, 2 gray)        │
│ [Proceed] [Close]               │
└─────────────────────────────────┘
```

#### Test 5 (Two Stars):
```
Expected Screen:
┌─────────────────────────────────┐
│ Level 1                         │
│ Best Score: 300                 │
│ Min Score: 500                  │
│ ★★☆ (2 yellow, 1 gray)        │
│ [Proceed] [Close]               │
└─────────────────────────────────┘
```

#### Test 6 (Three Stars):
```
Expected Screen:
┌─────────────────────────────────┐
│ Level 1                         │
│ Best Score: 650                 │
│ Min Score: 500                  │
│ ★★★ (All yellow)               │
│ [Proceed] [Close]               │
└─────────────────────────────────┘
```

---

## Time Tracking

| Step | Time | Done? |
|------|------|-------|
| Setup (5 min) | 5 min | ☐ |
| Test 1 (Panel) | 1 min | ☐ |
| Test 2 (Locked) | 1 min | ☐ |
| Test 3 (Zero) | 1 min | ☐ |
| Test 4 (One) | 1 min | ☐ |
| Test 5 (Two) | 1 min | ☐ |
| Test 6 (Three) | 1 min | ☐ |
| Total | ~12 min | ☐ |

---

## Final Verification

### All Tests Pass? ✅
```
☐ Panel opens/closes with D
☐ Locked buttons work
☐ 0 stars display correctly
☐ 1 star displays correctly
☐ 2 stars display correctly
☐ 3 stars display correctly
☐ Scores persist
☐ No console errors
```

### If YES:
🎉 **SYSTEM IS WORKING!**
- Everything is configured correctly
- Ready for actual gameplay testing
- You can remove DebugManager when done

### If NO:
🔧 **TROUBLESHOOTING NEEDED**
- Review TESTING_GUIDE.md
- Check console for specific errors
- Verify setup matches checklist above
- Re-read specific test instructions

---

## Sign-Off

**Date:** ___________
**Tester:** ___________

**All Tests Completed:** ☐ YES ☐ NO
**All Tests Passed:** ☐ YES ☐ NO

**Notes:**
_________________________________________________
_________________________________________________
_________________________________________________

---

## Next Steps

### If Testing Successful:
1. ✅ Leave DebugManager in scene for now
2. ✅ Play actual level
3. ✅ Complete level with a score
4. ✅ Return to menu
5. ✅ Click level button
6. ✅ Verify actual score shows
7. ✅ Verify stars match your score

### If Testing Fails:
1. ❌ Review troubleshooting section
2. ❌ Check console errors
3. ❌ Verify all setup steps
4. ❌ Redo failed test
5. ❌ Post error message if stuck

---

**Ready? Start with Test 1!** 🚀
