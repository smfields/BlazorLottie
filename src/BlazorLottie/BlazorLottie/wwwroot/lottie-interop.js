import './lottie.min.js';

class RegisteredEvent {
    constructor(jsEvent, dotnetFunction) {
        this.jsEvent = jsEvent;
        this.dotnetFunction = dotnetFunction;
    }
}

export function registerEventListeners(animation, dotnetObj) {
    const events = [
        new RegisteredEvent("enterFrame", "OnEnterFrame"),
        new RegisteredEvent("loopComplete", "OnLoopComplete"),
        new RegisteredEvent("complete", "OnComplete"),
        new RegisteredEvent("segmentStart", "OnSegmentStart"),
        new RegisteredEvent("destroy", "OnDestroy"),
        new RegisteredEvent("config_ready", "OnConfigReady"),
        new RegisteredEvent("data_ready", "OnDataReady"),
        new RegisteredEvent("DOMLoaded", "OnDomLoaded"),
        new RegisteredEvent("error", "OnError"),
        new RegisteredEvent("data_failed", "OnDataFailed"),
        new RegisteredEvent("loaded_images", "OnLoadedImages"),
    ]

    for (const event of events) {
        animation.addEventListener(event.jsEvent, async (args) => {
            await dotnetObj.invokeMethodAsync(event.dotnetFunction, args)
        })
    }
}

export function loadAnimation(params) {
    return lottie.loadAnimation(params);
}

export function play(name) {
    lottie.play(name);
}

export function pause(name) {
    lottie.pause(name);
}

export function stop(name) {
    lottie.stop(name);
}

export function setSpeed(speed, name) {
    lottie.setSpeed(speed, name);
}

export function setDirection(direction, name) {
    lottie.setDirection(direction, name);
}

export function searchAnimations(animationData, standalone, renderer) {
    lottie.searchAnimations(animationData, standalone, renderer);
}

export function destroy(name) {
    lottie.destroy(name);
}

export function registerAnimation(element, animationData) {
    lottie.registerAnimation(element, animationData);
}

export function setQuality(quality) {
    lottie.setQuality(quality);
}

export function setLocationHref(href) {
    lottie.setLocationHref(href);
}

export function setIDPrefix(prefix) {
    lottie.setIDPrefix(prefix);
}

Object.defineProperty(Object.prototype, "getProperty",
    {
        value: function getProperty(key) {
            return this[key];
        },
        writable: true,
        configurable: true
    });