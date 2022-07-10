export const onResize = (dotnetObjectReference) => {
    dotnetObjectReference.invokeMethodAsync("OnResizeNotifier", {
        windowDimensions: getWindowDimensions(),
        screen: getScreen()
    });
}

export const onOrientationChange = (dotnetObjectReference) => {
    dotnetObjectReference.invokeMethodAsync("OnOrientationChangeNotifier", {
        windowDimensions: getWindowDimensions(),
        screen: getScreen()
    });
}

export const registerEventHandlers = (dotnetObjectReference) => {
    window.addEventListener("resize", () => onResize(dotnetObjectReference));
    window.screen.orientation.addEventListener("change", () => onOrientationChange(dotnetObjectReference));
}

export const alert = (message) => {
    return window.alert(message);
}

export const prompt = (message) => {
    return window.prompt(message);
}

export const focus = () => {
    window.focus();
}

export const blur = () => {
    window.blur();
}

export const print = () => {
    window.print();
}

export const logToConsole = (message) => {
    console.log(message);
}

export const clearConsole = () => {
    console.clear();
}

export const startConsoleTimer = (timerLabel = "default") => {
    console.time(timerLabel);
}

export const logConsoleTimer = (timerLabel = "default") => {
    console.timeLog(timerLabel);
}

export const stopConsoleTimer = (timerLabel = "default") => {
    console.timeEnd(timerLabel);
}

export const matchesMedia = (mediaQuery) => {
    return window.matchMedia(mediaQuery).matches;
}

export const scrollTo = (x, y) => {
    window.scrollTo(x, y);
}

export const getScreen = () => {
    return {
            width: window.screen.width,
            height: window.screen.height,
            orientation: {
                type: window.screen.orientation.type,
                angle: window.screen.orientation.angle
            }
        };
}

export const getWindowDimensions = () => {
    return {
        innerWidth: window.innerWidth,
        innerHeight: window.innerHeight,
        outerWidth: window.outerWidth,
        outerHeight: window.outerHeight
    };
}
export const getScreenHeight = () => {
    return window.screen.height;
}

export const getScreenWidth = () => {
    return window.screen.width;
}

export const getScreenOrientation = () => {
    return window.screen.orientation.type;
}
