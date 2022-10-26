import './lottie.min.js';

const registeredEventHandlers = {};

export function loadAnimation(element, params) {
    params.container = element;
    const animation = lottie.loadAnimation(params);
    
    animation.registerEventHandler = function(dotnetObj, event, callback) {
        registeredEventHandlers[dotnetObj._id] = {
            [event]: {
                [callback]: async function(args) {
                    await dotnetObj.invokeMethodAsync(callback, args);
                }
            }
        }
        this.addEventListener(event, registeredEventHandlers[dotnetObj._id][event][callback]);
    }
    
    animation.unregisterEventListener = function(dotnetObj, event, callback) {
        this.removeEventListener(event, registeredEventHandlers[dotnetObj._id][event][callback]);
    }

    animation.getProperty = function(key) {
        return this[key];
    }
    
    return animation;
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