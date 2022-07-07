export const focus = (element) => {
    element.focus();
}

export const blur = (element) => {
    element.blur();
}

export const getProperty = (element, property) => {
    return element[property];
}

export const setProperty = (element, property, value) => {
    element[property] = value;
}

export const getStyle = (element, property) => {
    return element.style[property];
}

export const setStyle = (element, property, value) => {
    element.style[property] = value;
}

export const addClass = (element, className) => {
    element.classList.add(className);
}

export const toggleClass = (element, className) => {
    element.classList.toggle(className);
}

export const removeClass = (element, className) => {
    element.classList.remove(className);
}

