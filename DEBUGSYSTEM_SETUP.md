# 🐛 DebugLevelSystem - Fixed & Ready

## What Changed

✅ **Fixed the Arial.ttf error** - Now uses OnGUI instead of TextMeshPro
✅ **D key now works** - Press D to toggle debug panel
✅ **Better buttons** - Larger, easier to click
✅ **Status display** - Shows current unlock level and scores

---

## Quick Setup (1 minute)

### 1. Find the Script
- Location: `Assets/Scripts/UI/DebugLevelSystem.cs`
- Already created and ready to use

### 2. Add to Your Scene
- Open your Level Menu scene
- Create empty GameObject
- Name it: "DebugManager"
- Add Component: DebugLevelSystem
- Leave all settings default (they're already configured)

### 3. Play & Test
- Press Play
- Press 'D' key → Debug panel appears on left
- Click buttons to test

---

## Using the Debug Panel

### The Panel
```
When you press 'D', you see:

┌─────────────────────────────────┐
│    === DEBUG CONSOLE ===        │
│    Press 'D' to toggle panel    │
├─────────────────────────────────┤
│ ✓ Unlock All Levels             │
│ 🔒 Lock All Levels              │
│ 🔓 Unlock Level 2 Only          │
│                                 │
│ --- SCORE TESTING (6.4) ---     │
│ ★☆☆ Level 1: 150 (1 star)     │
│ ★★☆ Level 1: 300 (2 stars)    │
│ ★★★ Level 1: 650 (3 stars)    │
│ ☆☆☆ Clear Level 1 (0 stars)   │
│ ★★★ Level 2: 900 (3 stars)    │
│ 🗑️ Clear All Scores            │
│                                 │
│ --- CURRENT STATUS ---          │
│ Unlocked Level: 1               │
│ Level 1 Score: 0                │
│ Level 2 Score: 0                │
└─────────────────────────────────┘
```

### Controls
- **Press D** - Toggle panel on/off
- **Click buttons** - Execute actions immediately

---

## Test 1: Locked Buttons

### Steps
1. Play the game
2. Press 'D' → Debug panel appears
3. Look at your level buttons:
   - Level 1: Bright ✓
   - Level 2+: Dimmed with lock icon ✓
4. Try clicking Level 2 → Nothing happens ✓
5. Click "✓ Unlock All Levels"
6. Now all buttons should be bright ✓
7. Try clicking Level 2 → Popup appears ✓

### What You're Checking
- ✅ Locked levels are visually dimmed
- ✅ Locked levels have lock icon
- ✅ Clicking locked level does nothing
- ✅ Unlocking works
- ✅ Unlocked levels show popup

---

## Test 2: Score Display & Stars (6.4)

### Quick Test (2 minutes)
```
1. Press 'D'
2. Click "☆☆☆ Clear Level 1 (0 stars)"
3. Click Level 1 button
4. Look at stars → Should be all GRAY ✓

5. Click "★☆☆ Level 1: 150 (1 star)"
6. Click Level 1 button
7. Look at stars → Should be 1 YELLOW, 2 GRAY ✓

8. Click "★★☆ Level 1: 300 (2 stars)"
9. Click Level 1 button
10. Look at stars → Should be 2 YELLOW, 1 GRAY ✓

11. Click "★★★ Level 1: 650 (3 stars)"
12. Click Level 1 button
13. Look at stars → Should be all YELLOW ✓
```

### What You're Checking
| Score | Expected | Check |
|-------|----------|-------|
| 0 | ☆☆☆ (all gray) | ✓ All stars gray |
| 150 | ★☆☆ (1 yellow) | ✓ 1st star yellow, rest gray |
| 300 | ★★☆ (2 yellow) | ✓ 1st & 2nd yellow, 3rd gray |
| 650 | ★★★ (all yellow) | ✓ All stars yellow |

---

## Common Issues & Fixes

### Problem: D key doesn't work
**Solution:**
- Make sure DebugLevelSystem script is attached to a GameObject
- Make sure the GameObject is active
- Try pressing D multiple times
- Check console for error messages

### Problem: Debug panel doesn't appear
**Solution:**
- Make sure _showDebugPanel is ON (checked) in Inspector
- Make sure you're in Play mode
- Press D again - it might already be hidden

### Problem: Button clicks do nothing
**Solution:**
- Check console output - should show confirmation message
- Make sure Canvas is in the scene
- Try closing and reopening the panel (press D twice)

### Problem: Stars don't change
**Solution:**
- Make sure you clicked a button in the debug panel
- Wait 1 second after clicking
- Close popup and reopen it to refresh
- Check console for error messages

---

## Console Feedback

When you click buttons, check the console (Ctrl+` or Window > General > Console):

```
✓ All levels unlocked!
✓ Set Level1 score to 150
✓ Level 1 score to 300
✓ Cleared Level1 score
```

If you don't see these messages, something's wrong. Check:
1. Is DebugLevelSystem attached to a GameObject?
2. Is the GameObject active?
3. Are you in Play mode?

---

## Full Test Sequence (5 minutes)

```
STEP 1: INITIAL STATE
├─ Play game
├─ Don't press anything
├─ Level 1 button: Bright ✓
├─ Level 2 button: Dimmed ✓
└─ Lock icon on Level 2 ✓

STEP 2: TRY CLICKING LOCKED
├─ Click Level 2 button
├─ Expected: Nothing happens ✓
└─ No popup appears ✓

STEP 3: TEST ZERO STARS
├─ Press D to show debug panel
├─ Click "☆☆☆ Clear Level 1 (0 stars)"
├─ Click Level 1 button → Popup appears
└─ Check: All stars are gray ✓

STEP 4: TEST ONE STAR
├─ Debug panel still open
├─ Click "★☆☆ Level 1: 150 (1 star)"
├─ Close popup (click X or Close button)
├─ Click Level 1 button → Popup opens again
└─ Check: 1 yellow star, 2 gray stars ✓

STEP 5: TEST TWO STARS
├─ Click "★★☆ Level 1: 300 (2 stars)"
├─ Close popup
├─ Click Level 1 button
└─ Check: 2 yellow stars, 1 gray star ✓

STEP 6: TEST THREE STARS
├─ Click "★★★ Level 1: 650 (3 stars)"
├─ Close popup
├─ Click Level 1 button
└─ Check: All 3 stars are yellow ✓

STEP 7: TEST UNLOCK
├─ Click "✓ Unlock All Levels"
├─ Now ALL buttons should be bright
├─ Click Level 2 → Popup appears ✓
└─ Click Level 3 → Popup appears ✓

DONE! All tests passed ✅
```

---

## Button Quick Reference

### Unlock/Lock Buttons
```
✓ Unlock All Levels
  └─ Makes all level buttons clickable

🔒 Lock All Levels
  └─ Only allows Level 1 (default state)

🔓 Unlock Level 2 Only
  └─ Allows Levels 1-2, locks 3+
```

### Score Testing Buttons
```
★☆☆ Level 1: 150 (1 star)
  └─ Sets Level 1 score to 150 → Shows 1 star

★★☆ Level 1: 300 (2 stars)
  └─ Sets Level 1 score to 300 → Shows 2 stars

★★★ Level 1: 650 (3 stars)
  └─ Sets Level 1 score to 650 → Shows 3 stars

☆☆☆ Clear Level 1 (0 stars)
  └─ Removes Level 1 score → Shows 0 stars

★★★ Level 2: 900 (3 stars)
  └─ Sets Level 2 score to 900 → Shows 3 stars

🗑️ Clear All Scores
  └─ Removes all saved scores
```

---

## Status Display

The panel shows your current state:

```
--- CURRENT STATUS ---
Unlocked Level: 1        ← Up to which level is unlocked
Level 1 Score: 0         ← Your best score on Level 1
Level 2 Score: 0         ← Your best score on Level 2
```

This updates each time you click a button.

---

## Keyboard Shortcuts (Debug Panel Only)

| Key | Action |
|-----|--------|
| D | Toggle panel on/off |

That's it! Just D.

---

## What Gets Saved

All changes are saved to PlayerPrefs, which means:
- Scores persist when you close the game
- Unlock level persists when you close the game
- You can manually delete these by clicking "🗑️ Clear All Scores"

---

## Next Steps

### If Everything Works ✅
1. Close debug panel (press D)
2. Test your actual game
3. Verify popup appears when clicking levels
4. Verify stars display correctly
5. **Done!** The system is working

### If Something's Wrong ❌
1. Check console for error messages
2. Make sure DebugLevelSystem is in the scene
3. Make sure _showDebugPanel is ON
4. Try pressing D multiple times
5. Restart Play mode

---

## Pro Tips

1. **Quick Reset**: Click "🔒 Lock All Levels" + "🗑️ Clear All Scores" to return to default state

2. **Test Multiple Levels**: Click "✓ Unlock All Levels" then set different scores for each

3. **Rapid Testing**: Keep debug panel open, click buttons rapid-fire to test quickly

4. **Check Console**: Always check console output to see if actions completed successfully

---

## You're All Set! 🎮

Now you can:
- ✅ Test locked buttons
- ✅ Test star display (Test 6.4)
- ✅ Set custom scores
- ✅ Unlock/lock levels
- ✅ Reset everything

**Press Play, press D, and start testing!**
