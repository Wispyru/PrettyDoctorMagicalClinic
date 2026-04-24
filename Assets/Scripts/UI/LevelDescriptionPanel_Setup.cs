// LevelDescriptionPanel_Setup.cs
// 
// This file provides documentation and setup helpers for the Level Description Popup system.
// 
// SETUP INSTRUCTIONS:
// 
// 1. CREATE THE POPUP PANEL (Canvas UI):
//    - Create a new Canvas > Panel (or use existing description panel)
//    - Name it "DescriptionPanel"
//    - Add a RectTransform component and position it off-screen
//    - Set initial Y position to -1200 (or adjust to your preference)
//    
// 2. POPULATE PANEL ELEMENTS:
//    Create the following child elements within the DescriptionPanel:
//    
//    a) Level Title Text:
//       - Create: UI > TextMeshPro - Text (UI)
//       - Name: "LevelNameText"
//       - This displays the level name from TemporaryLevelData
//    
//    b) Description Text:
//       - Create: UI > TextMeshPro - Text (UI)
//       - Name: "DescriptionText"
//       - Use TextArea (TextMeshPro settings) for multi-line display
//       - This displays the level description from TemporaryLevelData
//    
//    c) Score Info:
//       - Create: UI > TextMeshPro - Text (UI)
//       - Name: "MinimumScoreText"
//       - Displays the minimum score requirement
//       - Create another: UI > TextMeshPro - Text (UI)
//       - Name: "PlayerScoreText"
//       - Displays the player's best score
//    
//    d) Star Rating Display:
//       - Create: Empty GameObject as container
//       - Name: "StarContainer"
//       - Add StarRating component to it
//       - Inside StarContainer, create 3 Image children named "Star1", "Star2", "Star3"
//       - Set each star image to use a star sprite (or UI Image with white color)
//       - In StarRating component inspector:
//         * Drag the 3 star images into the _stars array (in order)
//         * Set _filledStarColor to yellow (1, 1, 0, 1) or your preferred color
//         * Set _emptyStarColor to gray (0.5, 0.5, 0.5, 1) or your preferred color
//    
//    e) Buttons:
//       - Create: UI > Button (TextMeshPro)
//       - Name: "ProceedButton"
//       - Set button text to "Proceed" or "Start Level"
//       - In LevelMenu inspector, drag this button to _proceedButton field
//       - Set button onClick event: LevelMenu > OpenLevel()
//       
//       - Create: UI > Button (TextMeshPro)
//       - Name: "CloseButton"
//       - Set button text to "Back" or "Close"
//       - In LevelMenu inspector, drag this button to _closeButton field
//       - Set button onClick event: LevelMenu > HidePanel()
//    
// 3. CONNECT TO LEVELBUTTONS:
//    - For each level button, set its onClick event:
//    - Select: LevelMenu > OnLevelButtonClicked(levelNumber)
//    - levelNumber = 1 for the first level, 2 for second, etc.
//    
// 4. CONFIGURE LEVELDATA:
//    - In LevelMenu inspector, set the size of _TemporaryLevelData array
//    - For each level, fill in:
//      * Level Name (e.g., "Level 1: The Beginning")
//      * Description (e.g., "Cure 5 patients to unlock the next area")
//      * Minimum Score (e.g., 500)
//      * Maximum Score (e.g., 1000)
//    
// 5. TEST THE POPUP:
//    - Click a level button in-game
//    - The panel should slide up from the bottom
//    - Stars should display based on your previous best score:
//      * 1 star = 30% of minimum score
//      * 2 stars = 60% of minimum score
//      * 3 stars = 100% of minimum score (best score)
//    - Click "Proceed" to load the level
//    - Click "Close" to return to level menu
//    
// STAR SCORING SYSTEM:
// 1 Star: When score >= 30% of minimum score
// 2 Stars: When score >= 60% of minimum score
// 3 Stars: When score >= 100% of minimum score (or higher)
// 0 Stars: When score < 30% of minimum score
//
// You can modify the thresholds in StarRating.SetStars() if needed.

using UnityEngine;

public class LevelDescriptionPanel_Setup : MonoBehaviour
{
    // This is a documentation class only. No implementation needed.
}
