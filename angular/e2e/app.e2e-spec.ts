import { AspNetBoilerPlateTemplatePage } from './app.po';

describe('AspNetBoilerPlate App', function() {
  let page: AspNetBoilerPlateTemplatePage;

  beforeEach(() => {
    page = new AspNetBoilerPlateTemplatePage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
