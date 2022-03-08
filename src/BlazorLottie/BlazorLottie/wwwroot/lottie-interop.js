import './lottie.min.js';

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