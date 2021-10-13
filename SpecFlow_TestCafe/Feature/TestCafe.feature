Feature:Test Cafe

Scenario: Verify success page upon submitting with name populated
	Given I Launch the Test Cafe webpage
	And I Input Name <Name>
	And I click on submit button
	Then Success Page is displayed

	Examples:
		| Name  |
		| Peter |

Scenario: Verify submit button disabled when name is blank page
	Given I Launch the Test Cafe webpage
	And I Input Name <Name>
	Then I verify submit button is disabled

	Examples:
		| Name |
		|      |

Scenario: Verify Form can be submitted with Name and OS
	Given I Launch the Test Cafe webpage
	And I Input Name <Name>
	And I select Operating System as <OS>
	And I click on submit button
	Then Success Page is displayed

	Examples:
		| Name    | OS      |
		| Peter   | Windows |
		| Peter   | MacOS   |
		| Francis | Linux   |

Scenario: Verify Form Submission with Name,Remote Devices Features Checkbox
	Given I Launch the Test Cafe webpage
	And I Input Name <Name>
	And I select Remote Devices checkbox in important features
	And I click on submit button
	Then Success Page is displayed

	Examples:
		| Name  |
		| Peter |

Scenario: Verify Form Submission with Name, reuse javascript Features Checkbox
	Given I Launch the Test Cafe webpage
	And I Input Name <Name>
	And I select Remote Devices checkbox in important features
	And I Select Reuse JavaScript code in important features
	And I click on submit button
	Then Success Page is displayed

	Examples:
		| Name  |
		| Peter |

Scenario: Verify Form Submission with Name and Features Checkbox
	Given I Launch the Test Cafe webpage
	And I Input Name <Name>
	And I select all checkboxes in important features
	And I click on submit button
	Then Success Page is displayed

	Examples:
		| Name  |
		| Peter |

Scenario: Verify Form Submission with Name and tried test cafe Features
	Given I Launch the Test Cafe webpage
	And I Input Name <Name>
	And I select I have tried TestCafe checkbox
	And I select <Rating> in a slider
	And I input <Review> in What you think textarea
	And I click on submit button
	Then Success Page is displayed

	Examples:
		| Name  | Rating | Review |
		| Peter | 8      | Tested |

Scenario: Verify Form Submission with input to all the fields
	Given I Launch the Test Cafe webpage
	And I Input Name <Name>
	And I select Operating System as <OS>
	And I select all checkboxes in important features
	And I select I have tried TestCafe checkbox
	And I select <Rating> in a slider
	And I input <Review> in What you think textarea
	And I click on submit button
	Then Success Page is displayed

	Examples:
		| Name  | Rating | Review | OS      |
		| Peter | 8      | Tested | Windows |