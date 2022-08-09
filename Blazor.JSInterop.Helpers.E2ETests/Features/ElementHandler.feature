Feature: ElementHandler

Contains methods to interact with the DOM's HTMLElement APIs

Scenario: Add a class to an element
	When AddClassAsync is called with a class name
	Then the class name is added to the element

