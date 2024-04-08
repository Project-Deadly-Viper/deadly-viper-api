global using Microsoft.VisualStudio.TestTools.UnitTesting;

describe ('The main app', () => {

    it('should render the Orders link', () => {
        render (<App />);
        expect(screen.getByText('Orders')).toBeInTheDocument();
    });

    it('should render the Payments link', () => {
        render (<App />);
        expect(screen.getByText('Payments')).toBeInTheDocument();
    });

    it('should render the Home link', () => {
        render(<App />);
        expect(screen.getByText('Home')).toBeInTheDocument();
    });
});
