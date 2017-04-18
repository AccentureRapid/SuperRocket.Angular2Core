import { Angular2CoreTemplatePage } from './app.po';

describe('abp-project-name-template App', function() {
  let page: Angular2CoreTemplatePage;

  beforeEach(() => {
    page = new Angular2CoreTemplatePage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
