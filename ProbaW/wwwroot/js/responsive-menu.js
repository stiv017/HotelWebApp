var menuIsOpen = false;
function OpenCloseResponsiveMenu() 
{
	if (!menuIsOpen)
	{    
		$('.responsive-menu-side-navigation').css("width","100%");
		$('.responsive-menu-icon').css("marginTop","50px");
		$('.logo-image').css("display","none");
		menuIsOpen = true;
	}
	else
	{
		$('.responsive-menu-side-navigation').css("width","0%");
		$('.responsive-menu-icon').css("marginTop","4px");
		$('.logo-image').css("display","inherit");
		menuIsOpen = false;
	}	
}

