Mahmoud_Hassan_MirajMediaTask - Video Replacement Guide

Project Name: Mahmoud_Hassan_MirajMediaTask
Platform: Unity
Author: Mahmoud Hassan
Last Updated: April 9, 2025

---

1. Overview

This guide provides technical instructions for updating video assets used in the Interactive App. Videos are dynamically loaded at runtime from the StreamingAssets directory, allowing easy replacement without rebuilding the app or modifying code.

---

2. Video Asset Requirements

The application expects exactly six .mp4 files, corresponding to specific app states:

Filename     | Description                    | Required
-------------|--------------------------------|---------
idle.mp4     | Looped idle screen video       | Yes
one.mp4      | Video triggered by "One"       | Yes
two.mp4      | Video triggered by "Two"	      | Yes
three.mp4    | Video triggered by "Three"     | Yes
four.mp4     | Video triggered by "Four"      | Yes
five.mp4     | Video triggered by "Five"      | Yes

Important: Filenames are case-sensitive and must match exactly (lowercase, no spaces).

---

3. Folder Structure

Video files must be placed in:

Mahmoud_Hassan_MirajMediaTask/Assets/StreamingAssets/

If StreamingAssets does not exist, create it manually.

Example:

Assets/

	├── Scripts/

	├── Scenes/

	├── StreamingAssets/

   		├── idle.mp4

   		├── one.mp4

   		├── two.mp4

   		├── three.mp4

   		├── four.mp4

   		└── five.mp4

---

4. Replacement Instructions

1. Convert/export your new video to .mp4 format.
2. Rename it to match the appropriate filename (e.g., three.mp4).
3. Navigate to Assets/StreamingAssets/.
4. Replace the existing file:
   - Ensure the name is unchanged.
   - Overwrite the file.
5. Launch or rebuild the app to verify the change.

---

5. Technical Notes

- Video Format: .mp4 using the H.264 codec.
- Performance Recommendation: ≤ 1080p, max 30fps.
- Error Handling: If a file is missing or invalid, VideoManager.cs logs an error and skips playback.

---

6. Runtime Video Loading (Code Overview)

The system loads videos at runtime using this logic:

string path = Path.Combine(Application.streamingAssetsPath, "one.mp4");
videoPlayer.source = VideoSource.Url;
videoPlayer.url = path;
videoPlayer.Play();

This allows Unity to stream videos from disk without bundling them in the build.

---

7. Troubleshooting

Issue                  | Possible Cause              | Solution
------------------------|-----------------------------|------------------------------
Video doesn't play     | Missing or misnamed file    | Check file spelling and location
App crashes on select  | Corrupt/unsupported video   | Use H.264-encoded .mp4
Video lags or stutters | File too large or hi-res    | Optimize resolution and bitrate

---

8. Recommendations

- Maintain strict naming conventions.
- Test videos in Unity Editor before release.
- Keep a backup of default videos in version control.
