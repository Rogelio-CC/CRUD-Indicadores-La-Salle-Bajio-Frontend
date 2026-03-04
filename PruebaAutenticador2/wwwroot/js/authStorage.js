window.authStorageListener = (dotnetRef) => {
    window.addEventListener("storage", function (e) {
        if (e.key === "jwt-token") {
            dotnetRef.invokeMethodAsync("OnTokenRemoved");
        }
    });
};

