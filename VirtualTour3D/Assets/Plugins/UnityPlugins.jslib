mergeInto(LibraryManager.library, {
    SendSceneNameToReact: function(sceneNamePtr) {
        // Chuyển sceneName từ con trỏ UTF8 sang chuỗi
        var sceneName = UTF8ToString(sceneNamePtr);
        // Gửi tên scene đến React qua postMessage
        window.parent.postMessage({ type: "SCENE_NAME", name: sceneName }, "*");
        console.log("Hello World");
    }
});
