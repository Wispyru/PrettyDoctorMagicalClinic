# ⚡ Quick Test Guide - Locked Buttons & Test 6.4

## TL;DR - 5 Minute Setup

### Step 1: Add Debug Script (30 seconds)
1. Create empty GameObject in Canvas
2. Name: "DebugManager"
3. Add Component: DebugLevelSystem
4. Toggle _showDebugPanel to ON
5. Save and Play

### Step 2: Press 'D' During Gameplay
- Debug panel appears on left side of screen
- Click buttons to test

### Step 3: Test Locked Buttons
```
Default state:
✓ Level 1: Bright, clickable, no lock
✓ Level 2+: Dimmed, locked, lock icon visible

Click Level 2:
✓ NOTHING HAPPENS (it's locked)

Click Level 1:
✓ Popup appears with stars
```

### Step 4: Test Stars (6.4)
```
Using debug panel:

[Clear Level 1 Score] → Click Level 1 → ☆☆☆ ✓
[Set Level 1 Score: 150] → Click Level 1 → ★☆☆ ✓
[Set Level 1 Score: 300] → Click Level 1 → ★★☆ ✓
[Set Level 1 Score: 650] → Click Level 1 → ★★★ ✓
```

---

## What Are You Testing?

### Locked Buttons Test
**Question:** Do locked levels prevent access to the popup?

| Action | Expected | Pass? |
|--------|----------|-------|
| Click Level 1 (unlocked) | Popup appears | ✓ |
| Click Level 2 (locked) | Nothing happens | ✓ |
| Level 2 visually dimmed | Yes, appears grayed out | ✓ |
| Lock icon on Level 2 | Yes, lock icon visible | ✓ |

### Test 6.4 - Star Thresholds
**Question:** Do stars display correctly based on score?

| Score | Threshold | Expected | Pass? |
|-------|-----------|----------|-------|
| 0 | 0% < 30% | ☆☆☆ (all gray) | ✓ |
| 150 | 30% of 500 | ★☆☆ (1 filled) | ✓ |
| 300 | 60% of 500 | ★★☆ (2 filled) | ✓ |
| 650 | 100%+ of 500 | ★★★ (3 filled) | ✓ |

---

## Using Debug Panel

### Buttons Available
```
┌─ Unlock/Lock
├─ [Unlock All Levels]
├─ [Lock All Levels]
└─ [Unlock Level 2 Only]

┌─ Score Testing
├─ [Set Level 1 Score: 650 (3★)]
├─ [Set Level 1 Score: 300 (2★)]
├─ [Set Level 1 Score: 150 (1★)]
├─ [Clear Level 1 Score (0★)]
├─ [Set Level 2 Score: 900 (3★)]
└─ [Clear All Scores]

└─ Status Display
   Shows: Unlocked Level, Level 1 Score, Level 2 Score
```

### Keyboard
```
Press 'D' = Toggle debug panel on/off
```

---

## Step-by-Step Test (6.4)

### Test Case 1: Zero Stars
```
1. Press 'D' to show debug panel
2. Click "Clear Level 1 Score"
   └─ Console: "✓ Cleared Level1 score"
3. Click Level 1 button in game
4. Look at popup
5. VERIFY: ☆☆☆ (all gray stars)
✅ PASS = All stars are gray
❌ FAIL = Any star is yellow/filled
```

### Test Case 2: One Star
```
1. Press 'D'
2. Click "Set Level 1 Score: 150 (1★)"
   └─ Console: "✓ Set Level1 score to 150"
3. Click Level 1 button
4. Look at popup
5. VERIFY: ★☆☆ (first star yellow, rest gray)
✅ PASS = Exactly 1 yellow star
❌ FAIL = Wrong number of stars filled
```

### Test Case 3: Two Stars
```
1. Press 'D'
2. Click "Set Level 1 Score: 300 (2★)"
   └─ Console: "✓ Set Level1 score to 300"
3. Click Level 1 button
4. Look at popup
5. VERIFY: ★★☆ (two yellow, one gray)
✅ PASS = Exactly 2 yellow stars
❌ FAIL = Wrong number of stars filled
```

### Test Case 4: Three Stars
```
1. Press 'D'
2. Click "Set Level 1 Score: 650 (3★)"
   └─ Console: "✓ Set Level1 score to 650"
3. Click Level 1 button
4. Look at popup
5. VERIFY: ★★★ (all yellow)
✅ PASS = All 3 stars are yellow
❌ FAIL = Not all stars filled
```

---

## Locked Buttons Test

### Quick Check
```
1. Game starts
2. Look at buttons:
   ✓ Level 1: Bright
   ✓ Level 2: Dimmed (darker)
   ✓ Level 2: Has lock icon
3. Try clicking Level 2
   ✓ Nothing happens (or shake animation only)
4. Try clicking Level 1
   ✓ Popup appears
```

### Full Test
```
1. Press 'D'
2. Click "Lock All Levels"
3. Only Level 1 button should be bright ✓
4. Click "Unlock All Levels"
5. All buttons should be bright ✓
6. Click "Unlock Level 2 Only"
7. Levels 1-2 bright, 3+ dimmed ✓
8. Click Level 3 (locked) → Nothing ✓
9. Click Level 2 (unlocked) → Popup ✓
```

---

## Quick Verification Checklist

- [ ] Debug script added to scene
- [ ] Debug panel opens with 'D'
- [ ] Click "Clear Level 1 Score" → No stars (☆☆☆)
- [ ] Click "Set Level 1 Score: 150" → 1 star (★☆☆)
- [ ] Click "Set Level 1 Score: 300" → 2 stars (★★☆)
- [ ] Click "Set Level 1 Score: 650" → 3 stars (★★★)
- [ ] Click locked level button → Nothing happens
- [ ] Click unlocked level button → Popup appears
- [ ] Popup shows correct score
- [ ] Stars are correct color (yellow vs gray)

**All checked = READY TO DEPLOY!** ✅

---

## Colors Reference

**Filled Star** (Earned)
- Color: Yellow/Gold
- RGB: (1, 1, 0)
- Appearance: Bright yellow star

**Empty Star** (Not Earned)
- Color: Gray
- RGB: (0.5, 0.5, 0.5)
- Appearance: Dim gray star

---

## Important Score Thresholds

**Level 1 Minimum Score: 500**

| Score | % of Min | Calculation | Stars |
|-------|----------|-------------|-------|
| 0 | 0% | 0/500 | ☆☆☆ |
| 150 | 30% | 150/500 | ★☆☆ |
| 300 | 60% | 300/500 | ★★☆ |
| 500 | 100% | 500/500 | ★★★ |
| 650 | 130% | 650/500 | ★★★ |

**Level 2 Minimum Score: 800** (example)

| Score | % of Min | Stars |
|-------|----------|-------|
| 0 | 0% | ☆☆☆ |
| 240 | 30% | ★☆☆ |
| 480 | 60% | ★★☆ |
| 800+ | 100%+ | ★★★ |

---

## Troubleshooting Quick Fixes

**Debug panel doesn't appear?**
- Make sure _showDebugPanel is ON
- Make sure Canvas exists in scene
- Press 'D' to toggle

**Stars still gray after setting score?**
- Check console for error message
- Make sure you clicked the "Set Score" button
- Verify "Best Score: 150" appears in popup

**Locked levels still clickable?**
- Use "Lock All Levels" button to reset
- Verify Level 2 appears dimmed
- Try clicking again - should NOT open popup

**Wrong number of stars?**
- Check TemporaryLevelData for minimum score
- Verify score calculation: score/minScore * 100
- Check StarRating.SetStars() thresholds (30%, 60%, 100%)

---

## Debug Panel Layout

```
┌─────────────────────────────┐
│   === DEBUG CONSOLE ===     │
│   Press 'D' to toggle       │
├─────────────────────────────┤
│  [Unlock All Levels]        │
│  [Lock All Levels]          │
│  [Unlock Level 2 Only]      │
├─ --- Score Testing ---      │
│  [Set Level 1: 650 (3★)]    │
│  [Set Level 1: 300 (2★)]    │
│  [Set Level 1: 150 (1★)]    │
│  [Clear Level 1 (0★)]       │
│  [Set Level 2: 900 (3★)]    │
│  [Clear All Scores]         │
├─ --- Current Status ---     │
│  Unlocked Level: 1          │
│  Level 1 Score: 0           │
│  Level 2 Score: 0           │
└─────────────────────────────┘
```

---

## Timer: How Long Does This Take?

| Task | Time |
|------|------|
| Add debug script | 1 min |
| Initial unlock/lock test | 2 min |
| Test zero stars | 1 min |
| Test one star | 1 min |
| Test two stars | 1 min |
| Test three stars | 1 min |
| Test locked buttons | 2 min |
| **TOTAL** | **~10 minutes** |

---

## You're Ready!

Everything is set up for testing:
1. ✅ DebugLevelSystem.cs script created
2. ✅ Debug panel ready to use
3. ✅ All test buttons available
4. ✅ Console commands documented

**Just add the script and press 'D'!** 🎮
